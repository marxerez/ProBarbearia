export const navbarData = [
  {
    routerlink: 'inicio',
    icon: 'fal fa-home',
    label: 'Início',
    active:false,
    submenu: []

  },
  {
    routerlink: 'agenda',
    icon: 'fa-regular fa-calendar-days',
    label: 'Agenda',
    active:false,
    submenu: [{
      routerlink: '/pagina/minhaagenda',
      icon: 'fal fa-box-open',
      label: 'Minha Agenda'
    }, {
      routerlink: '/pagina/agenda',
      icon: 'fal fa-box-open',
      label: 'Marcar Atendimento'
    },
    {
      routerlink: '/pagina/gerenciaagenda',
      icon: 'fal fa-box-open',
      label: 'Gerenciar Agenda'
    }

    ]

  },
  {
    routerlink: '/pagina/cadastro',
    icon: 'fa-solid fa-gear',
    label: 'Cadastros',
    active:false,
    submenu: [{
      routerlink: '/pagina/usuario',
      icon: 'fa-solid fa-user',
      label: 'Usuário'
    }, {
      routerlink: '/pagina/profissional',
      icon: 'fa-solid fa-id-card-clip',
      label: 'Profissional'
    },
    {
      routerlink: '/pagina/servico',
      icon: 'fa-solid fa-scissors',
      label: 'Serviço'
    }

    ]
  },
  {
    routerlink: '/pagina/relatorio',
    icon: 'fal fa-chart-bar',
    label: 'Relatórios',
    active:false,
    submenu: []

  }

];

