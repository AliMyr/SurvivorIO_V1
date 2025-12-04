using System;
using System.Collections.Generic;
using UnityEngine;

public class WindowsService : MonoBehaviour
{
    [SerializeField] private Window[] windows;

    private Dictionary<Type, Window> windowsDictionary;

    public void Initialize()
    {
        windowsDictionary = new Dictionary<Type, Window>();

        foreach (Window window in windows)
        {
            windowsDictionary.Add(window.GetType(), window);
            window.Hide(true);
            window.Initialize();
        }

        ShowWindow<MainMenuWindow>(true);
    }

    public T GetWindow<T>() where T : Window
    {
        if (windowsDictionary.TryGetValue(typeof(T), out Window window))
        {
            return window as T;
        }
        return null;
    }

    public void ShowWindow<T>(bool isImmediately) where T : Window
    {
        if (windowsDictionary.TryGetValue(typeof(T), out Window window))
        {
            window.Show(isImmediately);
        }
        else
        {
            Debug.LogError($"Window of type {typeof(T).Name} not found");
        }
    }

    public void HideWindow<T>(bool isImmediately) where T : Window
    {
        if (windowsDictionary.TryGetValue(typeof(T), out Window window))
        {
            window.Hide(isImmediately);
        }
        else
        {
            Debug.LogError($"Window of type {typeof(T).Name} not found");
        }
    }
}