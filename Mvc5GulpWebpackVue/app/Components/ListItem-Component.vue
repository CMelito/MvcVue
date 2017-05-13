<template>
    <div>
        <div class="row">
            <div class="col-xs-12">
                <img :src="item.imageURL"
                     :alt="item.name"
                     class="img-responsive"
                     style="max-height: 300px; min-height: 300px;">
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <h1>{{ item.name }}</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="dropdown">
                    <button type="button"
                            class="btn btn-primary dropbtn">
                        Manage Recipe <span class="caret"></span>
                    </button>
                    <ul class="dropdown-content">
                        <li><a style="cursor: pointer;" @click="editRecipeItem(index)">Edit Recipe</a></li>
                        <li><a style="cursor: pointer;" @click="deleteRecipeAction(index)">Delete Recipe</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-12">
                {{item.description}}
            </div>
        </div>
        <ul class="list-group">
            <hr />
            <strong>Ingredients</strong>
            <div class="row" v-if="item.ingredients.length > 0" v-for="ingredient in item.ingredients">
                <div class="col-xs-12">
                    <li class="list-group-item" v-if="ingredient != ''">
                        {{ingredient}}
                    </li>
                </div>
            </div>
        </ul>
    </div>
</template>

<script>
    export default {
        props: ['item','index'],
        data() {
            return {
                
            }
        },
        methods: {
            deleteRecipeAction(index) {
                this.$emit('deleteRecipeAction', index);
            },
            editRecipeItem(index) {
                this.$emit('editRecipeItem', index);
            }
        }
    }
</script>

<style>
    /* Dropdown Button */
    .dropbtn {
        background-color: blue;
        color: white;
        padding: 16px;
        font-size: 16px;
        border: none;
        cursor: pointer;
    }

    /* The container <div> - needed to position the dropdown content */
    .dropdown {
        position: relative;
        display: inline-block;
    }

    /* Dropdown Content (Hidden by Default) */
    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f9f9f9;
        min-width: 190px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 1;
    }

        /* Links inside the dropdown */
        .dropdown-content a {
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
        }

            /* Change color of dropdown links on hover */
            .dropdown-content a:hover {
                background-color: #f1f1f1
            }

    /* Show the dropdown menu on hover */
    .dropdown:hover .dropdown-content {
        display: block;
    }

    /* Change the background color of the dropdown button when the dropdown content is shown */
    .dropdown:hover .dropbtn {
        background-color: blue;
    }
</style>