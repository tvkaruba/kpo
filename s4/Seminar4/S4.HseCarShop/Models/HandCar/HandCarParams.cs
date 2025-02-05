﻿namespace S4.HseCarShop.Models.HandCar;

/// <summary>
/// Параметры ручного автомобиля
/// </summary>
/// <param name="GripsType">Тип ручек</param>
/// <remarks>
/// Может показаться что этот класс копирует параметры двигателя, но просто представьте что у нас в автомобиле есть не только двигатели с их параметрами,
/// но и колеса, корпус и т.д. И у них могут быть свои фабрики со своими параметрами. 
/// Но это конечно жутко переусложненный пример исключительно в учебных целях :)
/// </remarks>
internal readonly record struct HandCarParams(GripsType GripsType);
