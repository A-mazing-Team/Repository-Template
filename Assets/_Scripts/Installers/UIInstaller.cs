using UnityEngine;
using Zenject;

public class UIInstaller : MonoInstaller
{
    [SerializeField] private GDPRUI _gdprUI;

    public override void InstallBindings()
    {
        Container.Bind<GDPRUI>().FromInstance(_gdprUI);
    }
}