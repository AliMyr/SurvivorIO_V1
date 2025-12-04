using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private Character playerCharacterPrefab;
    [SerializeField] private Character enemyCharacterPrefab;

    private readonly Dictionary<CharacterType, Queue<Character>> disabledCharacters =
        new Dictionary<CharacterType, Queue<Character>>();
    private readonly List<Character> activeCharacters = new List<Character>();

    public List<Character> ActiveCharacters => activeCharacters;
    public Character Player { get; private set; }

    public Character GetCharacter(CharacterType type)
    {
        Character character = null;

        if (disabledCharacters.TryGetValue(type, out Queue<Character> queue))
        {
            if (queue.Count > 0)
            {
                character = queue.Dequeue();
            }
        }
        else
        {
            disabledCharacters.Add(type, new Queue<Character>());
        }

        if (character == null)
        {
            character = InstantiateCharacter(type);
        }

        activeCharacters.Add(character);
        return character;
    }

    public void ReturnCharacter(Character character)
    {
        if (disabledCharacters.TryGetValue(character.CharacterType, out Queue<Character> queue))
        {
            queue.Enqueue(character);
        }
        activeCharacters.Remove(character);
    }

    private Character InstantiateCharacter(CharacterType type)
    {
        Character character = null;

        switch (type)
        {
            case CharacterType.Player:
                character = Instantiate(playerCharacterPrefab);
                Player = character;
                break;

            case CharacterType.DefaultEnemy:
                character = Instantiate(enemyCharacterPrefab);
                break;

            default:
                Debug.LogError($"Unknown character type: {type}");
                break;
        }

        return character;
    }
}