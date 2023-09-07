# ObjectiveTestExercise1

                                                              Описание методов

            Subscribe
            
            Метод: POST
            
    Путь: /subscribe/Subscribe
    
    Описание: Этот метод позволяет добавить подписку на изменение цены квартиры на сайте prinzip.su.

Тело запроса: JSON-объект с моделью AddSubscribeModel, который содержит ссылку на объявление и email для уведомлений.

Пример запроса:

POST https://localhost:7056/subscribe/Subscribe

{

    "url": "https://prinzip.su/apartments/12345",
    
    "email": "example@example.com"
    
}

Пример ответа (успешно):

200 OK

"Success"

Пример ответа (ошибка):

400 Bad Request

"Unsuccessfully"

            GetActualPrices
            
            Метод: GET
    
    Путь: /subscribe/GetActualPrices
    
    Описание: Этот метод позволяет получить актуальные цены на квартиры, для которых выполнена подписка.

Пример запроса:

GET https://localhost:7056/subscribe/GetActualPrices

Пример ответа (успешно):

200 OK
[

  {
  
  "url": "https://prinzip.su/apartments/12345",
  
  "price": 4522000},
  
  {"url": "https://prinzip.su/apartments/67890",
  
  "price": 3550000
  
  }
  
]

                                                                          Примечания:

Для парсинга сайта prinzip.su, API использует библиотеку Selenium.

Язык C#.

Платформа ASP.NET.

Данные о подписках и ценах хранятся в базе данных MSSQL.

БД развернута на сервере.

Для взаимодействия с базой данных используется Entity Framework Core.

Это API предоставляет удобный способ подписки на изменения цен и получения актуальных данных о квартирах с сайта prinzip.su.


                                                                        Параметры запуска
                                                      
В проекте есть папка "publish", внутри нее есть файл "ObjectiveTestExercise2.exe".

Для запуска приложения нужно запустить этот файл.

Для корректной работы не нужно менять состояние папки "publish". В ней находятся исполняемые файлы
