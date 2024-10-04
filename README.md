Programming practicum in OmSTU during 5th term
This practicum was promised to be about TESTING

**FIRST LAB**:

I have 3 following test cases:

1) Вход с некорректными учетными данными
2) Вход с пустыми полями
10) Подтверждение заказа и проверка успешного оформления

All the interface logic is contained within the Pages project,
which splits up to 3 files:

- ExpectCheckouts.cs (is responsible for all *'Expect'* checks)
- LoginPage.cs (is resposible for the first Login page)
- ProductsPage.cs (is responsible for the second Products page)

According to the mentioned use cases there are three tests:
- EmptyLoginTest (with EMPTY data filled in *First name* and *Second name* placeholders successively)
- IncorrectLoginTest (same as the first one but with the INCORRECT data)
- SuccessfullOrderTest (full cycle of successfull order process)

