Техническая документация
к игре Olympus trial

Тестирование игры в редакторе необходимо начинать со сцены START screen.

Немного про архитектуру и структуру проекта:

Метод Awake есть только у единственного синглтона, который служит точкой входа.
Метод Start используются только для подписок на события и получения компонента transform объектов, на которых повешены эти скрипты.
Методы Update и FixedUpdate используются только для управления персонажем с использованием физики.
Все поля сериализуются. Использование поиска объектов сведено к минимуму.
Скрипт всегда лежит на родительском объекте (за исключением случаев объединения однотипных объектов в группу для чистоты на сцене).
Классы разделены на пространства имен. Скрипты разложены по соответствующим пространствам имен папкам.
Код не содержит комментариев, так как имеются осмысленные названия и техническая документация.
Спрайты (за исключением UI маски) сделаны самостоятельно.


Пространство имен Data

Класс GameProgressManager является своего рода точкой входа для работы с прогрессом игры. В нем определен статический экземпляр Instance, который позволяет обращаться к этому классу из любого места в коде. Класс также имеет свойства для отслеживания уровня (LvlCount) и количества монет (CoinCounter), которые являются важными для игрового процесса.
При этом, класс GameProgressManager содержит методы IncrementScore и DecrementScore, которые увеличивают и уменьшают счетчик монет соответственно. Также класс GameProgressManager подписывается на события OnCoinTaken и OnCoinReset от объекта типа CoinBehavior, что позволяет увеличивать счетчик очков при взятии монет и уменьшать при проигрыше для корректного перезапуска уровня.
Таким образом, класс GameProgressManager выполняет роль централизованной точки управления игровым прогрессом и монетами, что подтверждает его статус как единой точки входа для некоторых аспектов игровой логики.

Класс Platform — ScriptableObject для установки параметров платформ. Имеет два сериализованных поля: isColorAllowed (логическое значение, указывающее, разрешено ли использование платформы данного цвета) и color (цвет платформы).
Таким образом данный класс позволяет создавать однотипные объекты (платформы) разных цветов, а так же устанавливать, может ли игрок встатть на платформу установленного цвета.


Пространство имен GamePlay.

Класс PlatformBehavior, реализует логику платформы в игровой сцене в зависимости от параметров, установленных через  ScriptableObject.
Класс содержит ссылки на данные платформы (platformData), коллайдер платформы (platformCollider) и отображаемый объект платформы (platformRenderer), а также аудио-источник для воспроизведения звука при неудачном взаимодействии с платформой (failSound).
В случае если платформа соответствующего цвета является недоступной для игрока, то ее коллайдер становится триггером. Игрок проваливается через платформу, слышит звук фейла и унывает.

Класс BallController отвечает за перемещение мяча в пространстве с помощью физической симуляции Rigidbody, а также за выполнение прыжков.
Класс содержит сериализованные поля для задания скорости перемещения (moveSpeed), силы прыжка (jumpForce), а также для аудио-источника для воспроизведения звука прыжка (jumpSound).
Класс также имеет Unity событие (UnityEvent) OnMovementStart, которое вызывается при начале движения мяча и сигнализирует о начале игры.

Класс CameraController, управляет поведением камеры в игровой сцене.
Камера следует за целевым объектом (target) с определенным сглаживанием движения (smoothSpeed).
Сериализованные поля определяют смещение камеры по оси Z (offsetZ) и Y (currentY), а также скорость сглаживания.

Класс CoinBehavior, отвечает за поведение монеты в игровом мире.
Класс содержит ссылку на аудио-источник (soundOfTakenCoin) для воспроизведения звука при сборе монеты, ссылку на аниматор (CoinAnimator) для управления анимацией монеты, а также два Unity события (OnCoinTaken и OnCoinReset), которые вызываются при сборе монеты и при перезапуске монеты соответственно.
Внутренняя переменная isCoinTaken отслеживает состояние монеты (взята она или нет).
При перезапуске уровня взятая монета возвращается на свое место, а очки, ранее полученные при ее взятии, списываются.

Класс DeathZoneLogic отвечает за зону смерти, возвращает игрока на начало уровня и запускает событие, которое возвращает объекты на сцене в первоначальное состояние.

Класс FinishLogic, управляет логикой завершения уровня в игре.
Класс содержит ссылки на массив систем частиц (particleSystemFirework) для отображения эффектов фейерверка при завершении уровня, и на аудио-источник (audioSource) для воспроизведения звука при завершении.
При триггере с объектом игрока запускаются феерверки и корутина, которая немного ждет, чтобы игрок полюбовался салютом, а потом загружает следующий уровень, обращаясь к асинхронному методу LoadNextScene класса NextSceneLoader.


Пространство имен NonMonobech.

Класс NextSceneLoader асинхронно запускает следующую сцену с момент, когда она загружена не менее чем на 90%.
Индекс сцены для загрузки получается путем инкремента значения  LvlCount из класса  GameProgressManager.

Пространство имен UI.
Класс GameStart содержит публичный метод для кнопки запуска игры из начального экрана.

Класс GideController открывает и скрывает обучение для игрока на первом уровне.
Содержит сериализуемые поля, которые являют собой текстовые объекты, отображающие информацию о том, как перемещаться и как прыгать (howToMoveText и howToJumpText), а также на объект, который указывает на то, что некоторые действия запрещены (prohiprohibited). 

Класс ScoreField выводит информацию о числе очков (монет) на экран. Обновляется при изменении числа очков (монет).# GBTestTaskTry3
