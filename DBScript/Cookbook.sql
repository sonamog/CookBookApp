IF DB_ID('Cookbook_DB') IS NULL
	CREATE DATABASE Cookbook_DB
GO

USE Cookbook_DB;

IF OBJECT_ID('dbo.tblRecipe') IS NOT NULL
	DROP TABLE dbo.tblRecipe;
GO

-- Please note ------------------------------------------------------------------------------------------------------ 
-- Category is a list of cuisines by region
---------------------------------------------------------------------------------------------------------------------

CREATE TABLE tblRecipe (
	Recipe_Id INT NOT NULL IDENTITY PRIMARY KEY,
	Recipe_Category NVARCHAR(50) NOT NULL,
	Recipe_name NVARCHAR(50) NOT NULL,
	Recipe_Description NVARCHAR(255) NOT NULL,
	Recipe_Date date
);

INSERT INTO tblRecipe (Recipe_Category, Recipe_name, Recipe_Description, Recipe_Date)
VALUES     ('American', 'Cioppino', 'It is made from the catch of the day, which in San Francisco is typically a combination of Dungeness crab, clams, shrimp, scallops, squid, mussels;  is then combined with fresh tomatoes in a wine sauce', '2018-05-25'),
	       ('African', 'Nshima', 'A dish made from maize flour and water. It is always eaten with a soup or stew or sauce', '2018-05-20'),
		   ('Asian', 'Som tom thai', 'Dish made of peanuts mixed with small rice crabs', '2018-05-18'),
		   ('Europe','Bigos','A Polish Hunters stew','2018-05-12'),
		   ('Oceanic', 'Curried Carrot and Turnip Soup','The soup is creamy because the vegetables are cooked, then pureed','2018-05-14'),	   
		   ('Asian', 'Pla Muek Yang', 'Fish sauce is a popular ingredient in several Asian cuisines made from salted, fermented fish', '2018-05-17'),
		   ('Europe', 'Sarmale', 'Traditional Romanian Cabbage Rolls with Pork and Rice ','2018-05-14'),
		   ('Oceanic', 'Aussie Meat Pie', 'filled with hearty goodness, including a tomato-based mix of lightly spiced ground beef', '2018-05-12'),
		   ('American', 'Creole Jambalaya', 'is a Louisiana-origin dish of Spanish and French consisting mainly of meat and vegetables mixed with rice', '2018-05-21' ),
	       ('African', 'Egusi soup', 'It is a melon seed soup originating from Nigeria', '2018-05-14'),
		   ('Oceanic', 'Tuna and Chickpea Patties', 'The patties are filled with tuna, vegetables, cilantro, parsley, and a little chile pepper', '2018-05-9'),
		   ('American', 'New England clam bake', 'Traditional new england flavors including lobster, clams, mussels. Spiced with chorizo and baked with potatoes, corn, onions, and herbs in white wine', '2018-05-13'),
	       ('African','Waakye','It is a Ghanaian dish of cooked rice and beans. The rice is cooked with an indigenous leaf and black eyed peas or kidney beans', '2018-05-13'),
		   ('Europe', 'Fenkata','Rabbit stew','2018-05-14' ),
		   ('Asian', 'Pepsi Rice', 'Pepsi rice was chef Dale Taldes grandmother contribution to the Filipino culinary canon','2018-05-13'),
		   ('Asian', 'La Paz Batchoy', 'It is a noodle soup made with pork offal, crushed pork cracklings, chicken stock, beef loin and round noodles','2018-05-12'),
		   ('Europe', 'Paella',' is a Valencian rice dish that has ancient roots but its modern form originated in the mid-19th century in the area around Albufera lagoon on the east coast of Spain adjacent to the city of Valencia.','2018-05-11'),
		   ('Oceanic', 'Lamb Roast','It is roasted on a bed of potatoes until it is mouth-wateringly delicious.','2018-05-12'),
		   ('American', 'Johns Chili', 'Mixture of serrano chile peppers, diced tomatoes, green chile peppers, tomato paste, kidney beans, garlic, lime juice, tequila, and beer into the pot', '2018-05-10'),
	       ('African', 'Doro wot', 'Doro wot is a chicken stew that contains an ethiopian spice called berbere', '2018-05-25'),
		   ('African', 'Mrouzia', 'It is a sweet and salty meat tajine, combining a ras el hanout blend of spices with honey, cinnamon and almonds', '2018-05-25'),
		   ('Asian', 'Ayam Jeruk', 'Is a finely shredded grilled chicken is tossed in an aromatic sambal with lime juice and toasted coconut', '2018-05-14'),
		   ('American', 'Green bean caserole', 'This is a casserole consisting of green beans, cream of mushroom soup, and french fried onions', '2018-05-14'),
		   ('Europe', 'Kottbullar','Swedish meatball is ground meat rolled into a small ball, sometimes along with other ingredients, such as bread crumbs, minced onion, eggs, butter, and seasoning','2018-05-12'),
		   ('Oceanic', 'Wallumbilla Crustless Quiche', 'This is a very simple to make quiche which you can “muck around” with. This is a wonderful way to use up any withering cold meat or veggies, or even cheese, in the freezer or fridge', '2018-05-17')

GO
