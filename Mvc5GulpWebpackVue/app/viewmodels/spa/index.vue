<template>
    <div>
         <hr>
         <List-Component :dataSource="recipes" @newRecipeAdded="recipes.push($event)"
                         @deleteRecipeAction="recipes.splice($event,1)"
                         @updateRecipe="recipes[$event[0]] = $event[1]"></List-Component>
    </div>
</template>

<script>
    import PeopleService from '../../services/people.service';
    import ListComponent from '../../Components/List-Component.vue';

    export default {
        data() {
            return {
                recipes: []
            }
        },
        mounted() {
            this.getData();
        },
        methods: {
            getData: function () {
                let svc = new PeopleService();
                svc.getPeople().then(response => this.recipes = response);
            },
            test(event) {
                console.log(event);
            }
        },
        components: {
            'List-Component': ListComponent
        }
    }
</script>