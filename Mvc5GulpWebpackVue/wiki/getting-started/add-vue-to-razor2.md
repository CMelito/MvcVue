[Getting Started](../getting-started.md)  
# Add Vue.js to Razor Part II  

In this section we will add Vue.js to a second razor view.

1. Repeat Steps 1-4 found in [Part I](./add-vue-to-razor1.md) but for the *About* view.  
* app/viewmodels/home/about.main.js
* app/viewmodels/home/about.vue
 
2. Update webpack.config.js -replace the entry and output with the following:  
```
entry: {
        'home.index': "./app/viewmodels/home/index.main.js",
        'home.about': "./app/viewmodels/home/about.main.js"
    },
    output: {
        path: path.resolve(__dirname, './dist'),
        publicPath: '/dist/',
        filename: '[name].bundle.js'
    },
```  
Now that we have multiple files we need to name our bundles in a way that makes sense.  By convention I'm using [controller name].[view name].bundle.js.

3. Now update both index.cshtml and about.cshtml to include the correct scripts
```
@Scripts.Render("/dist/" + "home.[view name goes here].bundle.js")
```
where [view name goes here] is *index* or *about*.

4. Run webpack to bundle javascript.

5. Run the project (F5). You may need to clear your cache (CTL+F5).

[Prev - Add Vue.js to Razor Part 1](add-vue-to-razor1.md)  
[Next - Improving our Development Workflow Part 1](improving-our-development-workflow1.md)