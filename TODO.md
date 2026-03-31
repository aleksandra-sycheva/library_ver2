# План исправления ошибок компиляции в library_ver2

## Шаг 1: Исправить FormReaderOrders.Designer.cs [ВЫПОЛНЕН]
- Заменить `partial class FormManageOrders` на `partial class FormReaderOrders`
- Переименовать все `dgvActiveOrders` → `dgvOrders` (в Name, инициализации, поле в конце)
- Удалить дубликаты контролей если появятся после фикса

## Шаг 2: Исправить FormManageOrders.cs [ВЫПОЛНЕН]
- В btnReturn_Click: 
  - Использовать `db.BookLoans.Find(selectedOrder.Id)`
  - `order.ActualReturnDate = DateTime.Now`
  - `book.Avaiable++`
  - SaveChanges()

## Шаг 3: Исправить FormReaderOrders.cs [НЕ НАЧАТ]
- Заменить все `ReturnDate` → `ActualReturnDate` (DataPropertyName, row.Cells["colReturnDate"], условия if)

## Шаг 4: Проверка и сборка [НЕ НАЧАТ]
- `dotnet build`
- Тестировать формы (FormBooks -> Orders)

## Шаг 5: Завершение [НЕ НАЧАТ]
- Обновить TODO.md как COMPLETED
- attempt_completion

*Примечание: Models не трогаем по просьбе пользователя. Если останутся ошибки Orders/ReturnDate — rebuild или данные в БД.*

