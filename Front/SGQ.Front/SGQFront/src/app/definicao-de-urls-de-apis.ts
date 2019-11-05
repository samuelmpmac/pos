export class DefinicaoDeUrlsDeApis{

  private readonly principal: string = 'https://localhost:2222/v1/';

  public get login() { return this.principal + 'auth/login'; }
  public get usuarios() { return this.principal + 'usuarios'; }
  public get pecas() { return this.principal + 'pecas'; }
  public get compliance() { return this.principal + 'compliance'; }

}
