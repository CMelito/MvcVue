[Getting Started](../getting-started.md)  
# Setup NPM

Previously adding npm (package.json) gave us the following:
```
{
  "version": "1.0.0",
  "name": "asp.net",
  "private": true,
  "devDependencies": {
  }
}
```

This file will contain all of the dependencies for both our application as well as the dependencies necessary to build our application. Since we know we are going to need Gulp and Webpack to build our application and since our application will use Vue.js let's install these packages now. We can install packages via the command line or by using the 'Quick Install Package...' option in Visual Studio (Shift+Alt+0). Let's install webpack using the 'Quick Install' method in Vistual Studio. Bring up the package dialog by right-clicking anywhere in the project and selecting 'Quick Install Package...' or by [Shift+Alt+0]. Ensure 'npm' is selected in the first dropdown and enter 'webpack' in the second dropdown as shown below and click [Install]:

![logo](./images/QuickInstallWebpack.png "Quick Install Package")

If we open or refresh package.json we will see the following in the "devDependencies" section:
```
"webpack": "^2.4.1"
```
Now, how did VS know to enter this as a 'dev' dependency? If you take a closer look at the dialog Visual Studio shows us what command it's going to run. In this case it ran 'npm install webpack --save-dev'. Adding the '-dev' argument is what tells npm to install the package as a 'dev' dependency. We are adding webpack to our dev workflow bundle our javascript code - specifically our Vue.js javascript code. 

Now let's install Vue.js the same way. Bring up the 'Quick Install Package' dialog and enter 'vue' in the second dropdown but do not click [Install] quite just yet.  

![logo](./images/QuickInstallVue1.png "Quick Install Package")  

Since Vue.js is not a 'dev' dependency we need to remove the '-dev' argument. Click on the '--save-dev' text as shown below:  

![logo](./images/QuickInstallVue2.png "Quick Install Package")  

Now remove the '-dev' argument as shown below and click [Install].  

![logo](./images/QuickInstallVue3.png "Quick Install Package")  

Now refresh or open package.json and you will see that Vue.js has no been added as a dependency.
```
  "dependencies": {
    "vue": "^2.2.6"
  }
```

The other and more common way to install packages is thru the command line. Open a new command prompt and navigate to the project directory.  If you have the 'Open Command Line' visual studio extension installed you can do this quickly by right-clicking on the project in the Solution Explorer. Install gulp by entering the following command:
```
npm install gulp --save-dev
```

Now refresh or open package.json and you will see that gulp was added as a 'dev' dependency. To this point package.json should look like the following:
```
{
  "version": "1.0.0",
  "name": "asp.net",
  "private": true,
  "devDependencies": {
    "gulp": "^3.9.1",
    "webpack": "^2.4.1"
  },
  "dependencies": {
    "vue": "^2.2.6"
  }
}
```

At this point all we have are configuration files and since we don't have any client-side assets to build or bundle we will define our dev workflow in a later section. In the next section we will add vue.js to one of our razor views at which point we will come back here and revisit our configuration files.

[Prev - Setup Client-Side Configuration](setup-client-side-configuration.md)  
[Next - Setup Client Directory Structure](setup-client-directory-structure.md)


