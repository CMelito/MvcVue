<template>
    <div>
        <div v-if="!isNewRecipe && !isEditRecipe">
            <button type="submit" @click="NewRecipeScreen" style="background-color: green; color: white;" class="btn btn-success">New Recipe</button>
            <div class="row">
                <div class="col-md-5 pre-scrollable">
                    <hr />
                    <a style="cursor: pointer;"
                       class="list-group-item clearfix"
                       v-for="(p, index) in dataSource"
                       @click="showDetails(p, index)"
                       v-if="p.name != '' && p.description != ''">
                        <div class="pull-left">
                            <h4 class="list-group-item-heading">{{p.name}}</h4>
                            <p class="list-group-item-text">{{p.description}}</p>
                        </div>
                        <div class="pull-right">
                            <img :src="p.imageURL" style="max-height: 100px; max-width: 100px;">
                        </div>
                    </a>
                </div>
                <div class="col-md-5">
                    <List-Item-Component :item="recipe" v-if="index >= 0" :index="index" 
                                         @deleteRecipeAction="deleteRecipeAction($event)"
                                         @editRecipeItem="editRecipeItem($event)"></List-Item-Component>
                </div>
            </div>
        </div>
        <!--------------------------------------------------------------------------------------------------------------------------------------------------------->
        <div v-if="isNewRecipe || isEditRecipe">
            <div class="row">
                <div class="col-xs-12">
                        <div class="row">
                            <div class="col-xs-12">
                                <button type="submit"
                                        class="btn btn-success"
                                        @click="saveRecipe">
                                    Save
                                </button>
                                <button type="button" class="btn btn-danger" @click="cancelNewRecipe">Cancel</button>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="name">Name</label>
                                    <input type="text"
                                           id="name"
                                           class="form-control"
                                           v-model="name">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="imagePath">Image URL</label>
                                    <input type="text"
                                           id="imagePath"
                                           formControlName="imagePath"
                                           class="form-control" 
                                           @change="updateImageURL"
                                           :value="editRecipe.imageURL">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <img :src="imageURL" style="max-height: 150px; max-width: 150px;">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="form-group">
                                    <label for="description">Description</label>
                                    <textarea type="text"
                                              id="description"
                                              class="form-control"
                                              formControlName="description"
                                              rows="6"
                                              v-model="description"></textarea>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-12">
                                <button type="button"
                                        class="btn btn-success"
                                        @click="addIngredient">
                                    Add Ingredient
                                </button>
                            </div>
                        </div>
                    <hr>
                        <div class="row" v-for="(ingredient,index) in ingredients" v-if="ingredients.length > 0 && isEditRecipe" >
                                    <div class="col-md-3" style="margin-top: 10px;">
                                        <input type="text"
                                       class="form-control"
                                       formControlName="name"
                                       @change="pushNewIngredient(index)"
                                       :value="editRecipe.ingredients[index]"
                                       >
                                    </div>
                                    <div class="col-xs-2" style="margin-top: 10px;">
                                        <button type="button"
                                        class="btn btn-danger"
                                        @click="deleteIngredient(index)">
                                                X
                                        </button>
                            </div>
                       </div>
                    <div class="row" v-for="(ingredient,index) in ingredients" v-if="ingredients.length > 0 && isNewRecipe">
                        <div class="col-md-3" style="margin-top: 10px;">
                            <input type="text"
                                   class="form-control"
                                   formControlName="name"
                                   @change="pushNewIngredient(index)"/>
                        </div>
                        <div class="col-xs-2" style="margin-top: 10px;">
                            <button type="button"
                                    class="btn btn-danger"
                                    @click="deleteIngredient(index)">
                                X
                            </button>
                        </div>

                    </div>
                    </div>
                </div>
            </div>
        </div>
</template>

<script>

    import ListItemComponent from '../Components/ListItem-Component.vue'
    export default {
        props: ['dataSource'],
        data() {
            return {
                ingredients: [],
                recipe: {},
                editRecipe: {},
                index: -1,
                isNewRecipe: false,
                isEditRecipe: false,
                name: '',
                imageURL: '',
                description: '',
                numbers: 0
            }
        },
        methods: {
            showDetails(recipe, index) {
                this.recipe = recipe;
                this.index = index;
            },
            NewRecipeScreen() {
                this.isNewRecipe = true;
            },
            resetPage() {
                this.index = -1;
                this.recipe = {};
                this.isNewRecipe = false;
                this.isEditRecipe = false;
                this.name = '';
                this.description = '';
                this.numbers = 0;
                this.ingredients = [];
                this.editRecipe = {};
            },
            saveRecipe() {
                if (this.isNewRecipe) {
                    var newRecipe = { name: this.name, description: this.description, ingredients: this.ingredients, imageURL: this.imageURL };
                    this.$emit('newRecipeAdded', newRecipe)
                }
                else {
                    var editRecipe = { name: this.name, description: this.description, ingredients: this.ingredients, imageURL: this.editRecipe.imageURL };
                    this.$emit('updateRecipe', [this.index, editRecipe]);
                }
                this.resetPage();
            },
            cancelNewRecipe() {
                this.resetPage();
            },
            updateImageURL() {
                this.imageURL = event.target.value;
                this.editRecipe.imageURL = event.target.value;
            },
            addIngredient() {
                this.ingredients.push('');
            },
            pushNewIngredient(index) {
                this.ingredients[index] = event.target.value;
            },
            deleteIngredient(index) {
                this.ingredients.splice(index,1);
            },
            deleteRecipeAction(index) {
                this.$emit('deleteRecipeAction', index);
                this.resetPage();
            },
            editRecipeItem(index) {
                this.isEditRecipe = true;
                this.editRecipe = this.recipe;
                this.ingredients = this.editRecipe.ingredients;
                this.description = this.editRecipe.description;
                this.name = this.editRecipe.name;
            }
        },
        components: {
            'List-Item-Component': ListItemComponent
        }
    }
</script>