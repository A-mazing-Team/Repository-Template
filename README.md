
# A-mazing Team

Краткое описание цикла разработки проекта.
##  Разделы

- [Этапы разработки](#Этапы-разработки)
- [Шаблона проекта](#Шаблон-проекта)

## Этапы разработки

1. Обсуждение времени разработки, и сложности проекта.
2. Загрузка репозитория. В нём уже содержится, частично либо полностью, визуал/контент.
3. Разработка проекта. Желательно каждый день делать коммит в GitHub, и скидывать видео прогресса разработки (показать механику или фичу, над которой работал)
4. Выгрузить тестовую сборку для теста внутри студии.
5. После сабмита от ГД, проект смотрит издатель, и может дать какие-то рекомендации. Если есть - возврат к шагу 3.
## Шаблон проекта

#### Директории / паки:
![](https://i.ibb.co/CvnD1Mr/2.png)

В папке **_Scenes** содержатся файлы:
- Main - главная игровая сцена

В папке **_Sprites** содержатся файлы:
- Ingame - примитивные фигуры, и стандартные иконки
- Promo - иконка и сплэш-скрин для игры

В папке **Third-party** содержатся паки:
- **AlmostEngine** - плагин создания скриншотов для стора
- **Confetti FX** - партиклы конфетти
- **Demigiant** - [DOTween](http://dotween.demigiant.com)
- **Epic Toon FX** - партиклы эффектов
- **FatMachines** - плагин мультиплатформенной вибрации
- **FlatKit** - шейдеры для мультизации моделек
- **GabrielAguiarProductions** - партиклы снарядов
- **GUI PRO Kit - Casual Game** - модульный UI
- **LunarConsole** - мобильная дебаг-консоль
- **PolygonIcons** - набор иконок в 3D
- **PolygonParticleFX** - набор полигональных партиклов

#### Иерархия проекта:
![](https://i.ibb.co/4WvJvnf/1.png)

Назначение:
* **[Map]**
  * Location - корневая папка для уровня
  * Other - для статичных объектов уровня (свет тд)
* **[Interface]**
  * Main - основной Canvas интерфейса
    * Game - объект для размещения внутриигрового интерфейса (шкала прогресса, настройки тд)
    * Windows - корневой объект для игровых окон (победа/поражение)
* **[Renderer]**
  * Main Camera - главная камера на сцене
