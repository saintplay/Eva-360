<template>
    <div class="column is-12">
        <section class="hero is-small">
            <div class="hero-body">
                <div class="container">
                    <h1 class="title">
                        Hola <strong>{{ usuario_nombre }}</strong>!
                    </h1>
                    <h2 class="subtitle">
                        Bienvenido al sistema de Gestión de Evaluaciones EVA 360
                    </h2>
                </div>
            </div>
            <div class="hero-foot">
                <nav class="level">
                    <div class="level-item has-text-centered">
                        <p class="heading">Usuarios</p>
                        <p class="title">{{ stats.usuarios }}</p>
                    </div>
                    <div class="level-item has-text-centered">
                        <p class="heading">Informes 360</p>
                        <p class="title">{{ stats.usuarios }}</p>
                    </div>
                    <div class="level-item has-text-centered">
                        <p class="heading">Periodos</p>
                        <p class="title">{{ stats.periodos }}</p>
                    </div>
                    <div class="level-item has-text-centered">
                        <p class="heading">Posts</p>
                        <p class="title">{{ stats.posts }}</p>
                    </div>
                </nav>
            </div>
        </section>

        <section class="section">
            <div class="container">
                <div class="columns">
                    <div class="column is-4">
                        <div class="card">
                            <header class="card-header">
                                <p class="card-header-title has-text-centered">
                                    Usuarios
                                </p>
                                <span class="card-header-icon">
                                <span class="icon">
                                    <i class="fa fa-user"></i>
                                </span>
                                </span>
                            </header>
                            <div class="card-content">
                                <div class="content">
                                    Administra lista de Usuarios.
                                </div>
                            </div>
                            <footer class="card-footer">
                                <router-link to="/Usuarios" class="card-footer-item">Administrar</router-link>
                            </footer>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>

<script>
export default {
    props: ['usuario_nombre'],
    data() {
        return {
            stats: {
                usuarios: 0,
                informes: 0,
                periodos: 0,
                posts: 0
            }
        }
    }
}
</script>