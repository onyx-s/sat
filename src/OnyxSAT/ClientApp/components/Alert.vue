<template>
    <div class="alert alert-warning alert-dismissible fade show w-100" role="alert">
        <button type="button" class="close p-0" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
            {{ message }}
    </div>
</template>
<script>
export default {
    name: 'alert',
    props: ['message'],
    data() {
        return {
        }
    }
}
</script>

<style lang="sass">
.alert-dismissible .close
    top: -6px
    right: -10px
</style>