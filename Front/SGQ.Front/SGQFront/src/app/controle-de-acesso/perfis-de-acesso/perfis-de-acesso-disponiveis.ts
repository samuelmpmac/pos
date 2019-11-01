export enum PerfisDeAcessoDisponiveis {
    AdministradorDeProcessos,
    AdministradorDoControleDeAcesso
}

export const TextoDosPerfisDeAcessoDisponiveis = new Map<number, string>([
    [PerfisDeAcessoDisponiveis.AdministradorDeProcessos, 'Administrador de processos'],
    [PerfisDeAcessoDisponiveis.AdministradorDoControleDeAcesso, 'Administrador do controle de acesso']
]);


