using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MainMenu>().FromComponentInHierarchy().AsSingle();
        Container.Bind<TimeManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ScoreManager>().FromComponentInHierarchy().AsSingle();
    }
}
