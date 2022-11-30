# Building an e-commerce web app with blazor and tailwind css

The architectural approach for this project is based on the “Clean Architecture” design by 
[Robert C Martin (Uncle Bob)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html).
An illustration of this design paradigm is shown below:
![alt text](clean-code.jpg)

#### Notes

Initially, we use an in memory datastore so we can work on building the
app without the distraction of entity framework at this juncture.
We will use EF later on in the build.