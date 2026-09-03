Application
Application under test: https://www.saucedemo.com/
Test type: Functional testing
Browser: Google Chrome
Automation: Selenium WebDriver
Language: C#
Test framework: NUnit
Design pattern: Page Object Pattern

Login
Positive scenarios:
1. Verify that the user is redirected to the Products page after successful login.
2. Verify that the Login page is opened successfully.
3. Verify that the Username field is displayed.
4. Verify that the Password field is displayed.
5. Verify that the Login button is displayed.
6. Login with valid username and valid password.
   Negative scenarios:
1. Verify that an error message is displayed for invalid login data.
2. Verify that a locked user cannot login.
3. Login with an incorrect username.
4. Login with an incorrect password.
5. Login with an empty username.
6. Login with an empty password.
7. Login with both fields empty.

Products
1. Verify that the Products page is displayed after successful login.
2. Verify that the Products title is displayed.
3. Verify that the products list is displayed.
4. Verify that each product has a name.
5. Verify that each product has a description.
6. Verify that each product has a price.
7. Verify that each product has an image.
8. Verify that each product has an Add to cart button.
9. Verify that the shopping cart icon is displayed.
10. Add a product to the cart.
11. Verify that the product is added to the cart.
12. Verify that the cart counter is updated after adding a product.
13. Add multiple products to the cart.
14. Verify that all selected products are added to the cart.
15. Verify that product has a Remove button after product is added to cart.

Product sorting
1. Sort products by Name A to Z.
2. Verify that products are sorted alphabetically from A to Z.
3. Sort products by Name Z to A.
4. Verify that products are sorted alphabetically from Z to A.
5. Sort products by Price low to high.
6. Verify that products are sorted from the lowest price to the highest price.
7. Sort products by Price high to low.
8. Verify that products are sorted from the highest price to the lowest price.

Product details
1. Open product details by clicking the product name.
2. Verify that the product details page is displayed.
3. Verify that the product name is displayed.
4. Verify that the product description is displayed.
5. Verify that the product price is displayed.
6. Verify that the product image is displayed.
7. Add the product to the cart from the product details page.
8. Verify that product has a Remove button after product is added to cart.
9. Verify that the product is added to the cart.
10. Remove the product from the cart.
11. Verify that the product is removed from the cart.
12. Return to the Products page.

Shopping cart
Positive scenarios:
1. Open the shopping cart.
2. Verify that the Cart page is displayed.
3. Verify that an empty cart does not contain products.
4. Add one product to the cart.
5. Verify that the added product is displayed.
6. Verify that the product name is correct.
7. Verify that the product price is correct.
8. Add multiple products to the cart.
9. Verify that all selected products are displayed in the cart.
10. Verify that Remove buttons are displayed near each product.

Negative scenarios:
1. Remove a product from the cart.
2. Verify that the removed product is no longer displayed.
3. Remove all products from the cart.
4. Verify that the cart becomes empty.
5. Verify that the cart counter is updated after removing a product.

Checkout
Positive scenarios:
1. Open checkout from the shopping cart.
2. Verify that the Checkout page is displayed.
3. Verify that the First Name field is displayed.
4. Verify that the Last Name field is displayed.
5. Verify that the Postal Code field is displayed.
6. Enter valid First Name.
7. Enter valid Last Name.
8. Enter valid Postal Code.
9. Continue to the checkout overview.
10. Verify that the Checkout Overview page is displayed.
11. Verify that the selected product is displayed.
12. Verify that the product price is correct.
13. Verify that the Price Total is displayed.
14. Verify that the Price Total is calculated correctly.
15. Complete the order.
16. Verify that the order confirmation page is displayed.
17. Verify that the order completion message is displayed.

Negative scenarios:
1. Continue checkout with an empty First Name.
2. Continue checkout with an empty Last Name.
3. Continue checkout with an empty Postal Code.
4. Verify that an appropriate validation message is displayed.

Navigation
1. Verify that the hamburger menu is displayed.
2. Open the hamburger menu.
3. Navigate to All Items page.
4. Verify that the Products page is opened.
5. Navigate to About page.
6. Verify that the About page is opened.
7. Navigate back to the Products page.
8. Navigate to the shopping cart from the Products page.

Logout
1. Login with valid credentials.
2. Open the hamburger menu.
3. Click Logout.
4. Verify that the user is redirected to the Login page.
5. Verify that the user cannot access the Products page after logout.
6. Verify that the login page is displayed after logout.

Test Data
Standard user
Username:
standard_user
Password:
secret_sauce
Locked out user
Username:
locked_out_user
Password:
secret_sauce

Result
The checklist covers the main functional areas of the SauceDemo application:
Login
Products
Product sorting
Product details
Shopping cart
Checkout
Navigation
Logout
