using Mock.ConsultoriasEAcessorias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.ConsultoriasEAcessorias.Repositorios
{
    public class RepositorioDeControlesDeGovernanca
    {
        public ControleDeGovernanca ObterPeloIdentificador(Int32 identificador)

        {
            return ObterTodos().SingleOrDefault(c => c.Identificador == identificador);
        }

        public IEnumerable<ControleDeGovernanca> ObterTodos(String filtro = null)
        {
            var resultado = new List<ControleDeGovernanca>()
            {
                new ControleDeGovernanca()
                {
                    Identificador = 1,
                    Nome = "Controle 1",
                    Descricao = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas scelerisque quam et ornare lacinia. Donec at neque nisl. Phasellus consectetur non nisl sit amet lobortis. Mauris egestas venenatis eleifend. Fusce a aliquet nulla, ut euismod magna. Cras auctor sed urna non laoreet. In ac sem quis elit volutpat dapibus. Nam tristique magna ex, ac aliquam nulla eleifend vel.",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 1001,
                            Descricao = "Duis eget pulvinar ante. Vivamus porta pulvinar maximus. Duis efficitur efficitur augue eu ultrices. Proin diam arcu, sagittis eu fringilla vel, varius eu purus. In hac habitasse platea dictumst. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Cras justo ligula, vestibulum quis feugiat feugiat, rhoncus et ante. In id nunc ac tellus dignissim accumsan a sit amet nisi. Suspendisse auctor, augue non porta auctor, nibh metus mollis justo, non ultrices lorem mi a ex. In eleifend, ipsum sed vestibulum cursus, enim nisi maximus leo, eget accumsan nulla purus et sem. Sed pellentesque eros felis. Suspendisse sit amet nulla a massa ornare iaculis sit amet facilisis tellus. Nunc ac neque lorem."
                        },
                        new Procedimento()
                        {
                            Identificador = 1002,
                            Descricao = "Maecenas at urna sit amet sem sagittis tempus fringilla non mauris. Donec auctor magna quis nunc facilisis finibus. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nullam ipsum purus, maximus eu fermentum nec, egestas eu lectus. Vestibulum malesuada interdum pretium. Donec quis massa at metus aliquet iaculis. In quis imperdiet purus, eu sollicitudin justo. Praesent pharetra vestibulum orci egestas imperdiet. Praesent sit amet tellus neque. Morbi sed felis sit amet mauris gravida tempus. In hac habitasse platea dictumst. Donec neque augue, faucibus sed diam vitae, scelerisque sodales magna. Vestibulum sed fringilla lorem. Suspendisse sit amet placerat turpis, in sollicitudin diam."
                        },
                        new Procedimento()
                        {
                            Identificador = 1003,
                            Descricao = "Ut non blandit metus, non sollicitudin risus. Nullam euismod ligula eu orci lobortis sodales. Proin eleifend faucibus malesuada. Pellentesque ut finibus lacus. Maecenas pharetra hendrerit purus non semper. Sed rutrum pulvinar magna. Nam lobortis ullamcorper mauris, et tincidunt est tristique vitae. In consequat at ligula volutpat elementum. Fusce id eleifend odio. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nam eget lorem luctus felis pharetra tempor vel non risus. Pellentesque pulvinar volutpat lectus ut convallis. Phasellus interdum ante in augue porttitor, quis consequat enim venenatis. Morbi pretium sem at sapien pulvinar lacinia. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae;"
                        },
                        new Procedimento()
                        {
                            Identificador = 1004,
                            Descricao = "Nullam ultrices ipsum tempor, consectetur orci sed, sollicitudin metus. Fusce porttitor, risus a malesuada placerat, leo dolor aliquet orci, et posuere tellus nibh sed tellus. Etiam facilisis, eros sed maximus tempus, orci eros ultrices tortor, euismod pretium ipsum ante nec ipsum. Curabitur lobortis mattis sem sit amet interdum. Suspendisse elit eros, malesuada cursus tempus quis, luctus a sem. Donec sagittis tortor eros, vel finibus justo aliquet at. Vivamus hendrerit tempor nisl sed imperdiet. Pellentesque auctor, orci in efficitur facilisis, eros nunc laoreet mi, in luctus quam velit id mi. Vestibulum ut accumsan est."
                        }

                    }
                },
                new ControleDeGovernanca()
                {
                    Identificador = 2,
                    Nome = "Controle 2",
                    Descricao = "Ut ut libero tempor lectus rhoncus tincidunt id non mi. Vestibulum eget feugiat erat. Cras sed mauris lorem. Aenean velit lacus, viverra vitae consequat sit amet, gravida id leo. Sed sed lacinia magna. Phasellus efficitur at ex vitae fringilla. Curabitur aliquam tincidunt magna, nec aliquam elit sollicitudin non. Ut ut neque in turpis porttitor commodo ut in nulla. Nullam quis ex eget urna faucibus tincidunt. Suspendisse potenti. Aliquam eu pharetra ex, eu finibus elit. Nulla lacus velit, fringilla id nisi a, iaculis mattis mi. Sed blandit ipsum quis pulvinar vestibulum. Aliquam faucibus justo elit. Aenean vehicula lobortis turpis, at placerat ipsum tincidunt id. Donec gravida tincidunt velit eu molestie",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 2001,
                            Descricao = "Nulla sagittis libero a ultricies pellentesque. Cras et odio a orci tristique sagittis. Morbi lorem mi, pretium ut lectus at, laoreet mattis metus. Sed interdum posuere ante, in sollicitudin ipsum laoreet ut. Vivamus vitae metus dignissim massa vulputate vestibulum. In quis arcu tortor. Proin nunc dui, ornare non blandit sit amet, iaculis id diam. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Suspendisse turpis purus, cursus ac molestie bibendum, fringilla ac nisi. Duis lacinia turpis at iaculis blandit. Integer vitae interdum elit. Sed sodales mollis orci eget accumsan. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis non odio blandit, sagittis ipsum non, interdum ipsum."
                        },
                        new Procedimento()
                        {
                            Identificador = 2002,
                            Descricao = "Pellentesque accumsan libero sed pulvinar interdum. Pellentesque iaculis facilisis purus, non blandit enim venenatis sit amet. Cras sit amet tempor magna, rhoncus dignissim massa. Donec mattis ullamcorper sapien, a hendrerit turpis maximus quis. Etiam et velit posuere, hendrerit augue et, blandit magna. Curabitur dictum tincidunt massa, at dignissim libero fermentum et. Fusce sed scelerisque ipsum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Nulla ac condimentum urna. Mauris placerat turpis luctus pellentesque varius. Ut sit amet nunc id felis consequat scelerisque. Donec sit amet sapien sed magna euismod aliquam."
                        },
                        new Procedimento()
                        {
                            Identificador = 2003,
                            Descricao = "Quisque nec neque vel diam dapibus cursus. Etiam laoreet vitae urna et placerat. Aenean a nisl mi. Phasellus lacus velit, suscipit ac vulputate a, iaculis id sapien. Praesent varius elementum sapien sed pretium. Phasellus sed ligula mollis, condimentum elit et, sagittis tortor. Vivamus fringilla, mauris nec semper porttitor, lorem sem accumsan nulla, ac efficitur purus ligula id urna."
                        },
                        new Procedimento()
                        {
                            Identificador = 2004,
                            Descricao = "Praesent rutrum fermentum sodales. Nam imperdiet porta posuere. Sed feugiat urna in dui molestie, ac faucibus sapien commodo. Etiam iaculis ornare nunc vitae rutrum. Praesent lobortis, quam eu auctor pharetra, mauris magna consequat orci, vel aliquam nibh erat eu orci. Fusce in sapien accumsan, egestas erat sed, sagittis tortor. Mauris iaculis nunc lectus, vel pretium purus tempus nec."
                        }

                    }
                },
                new ControleDeGovernanca()
                {
                    Identificador = 3,
                    Nome = "Controle 3",
                    Descricao = "Praesent molestie placerat libero imperdiet vestibulum. Vestibulum vel sollicitudin sapien. Maecenas molestie dolor in porttitor dapibus. Nulla ut est at felis imperdiet mollis. Fusce ut odio ipsum. Nulla facilisi. Vivamus posuere mauris nec euismod volutpat. Nullam eget imperdiet elit. Duis et placerat arcu. Donec turpis risus, luctus at placerat non, malesuada vitae arcu. Phasellus porta lacus varius, rhoncus mauris ac, porta ligula. Phasellus ullamcorper metus et nunc blandit, quis sodales justo pretium",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 3001,
                            Descricao = "Sed eget fringilla felis. Nam nec ligula augue. Quisque in convallis massa. Praesent id maximus velit, a pretium tortor. Aliquam orci velit, pellentesque at dapibus vitae, feugiat non ante. Donec varius in velit et ultricies. Vivamus justo lectus, fringilla eget posuere at, suscipit et nunc. Donec lobortis, turpis sed convallis congue, velit dui laoreet dolor, nec convallis mi augue in odio. Nunc sed diam non dolor vulputate condimentum. Quisque luctus hendrerit consequat. In vitae tristique nisl. Aenean fringilla nunc eget laoreet consequat. Nam lobortis dolor eget eros egestas tincidunt. Interdum et malesuada fames ac ante ipsum primis in faucibus."
                        },
                        new Procedimento()
                        {
                            Identificador = 3002,
                            Descricao = "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec facilisis, lectus at viverra scelerisque, sem dui cursus orci, quis consectetur ex neque ut massa. Morbi ultricies, est id placerat suscipit, leo ante imperdiet ex, a ornare metus sem a lectus. Mauris euismod quam porta, facilisis magna vitae, congue purus. Proin tincidunt molestie aliquam. Sed lacinia porttitor auctor. In porta sodales maximus. Pellentesque lacus magna, ultricies id lorem ut, vehicula consectetur velit. Cras scelerisque ligula nec turpis varius, non dapibus enim semper. Cras dapibus felis a bibendum semper."
                        }
                    }
                },
                new ControleDeGovernanca()
                {
                    Identificador = 4,
                    Nome = "Controle 4",
                    Descricao = "Duis vestibulum dignissim interdum. Donec ac purus accumsan, mattis nisl at, congue ligula. Etiam sapien enim, tristique ac consectetur nec, vehicula efficitur leo. Pellentesque pellentesque eu metus id fermentum. Nulla sed dui non velit pharetra feugiat ut in eros. Ut auctor, libero sit amet ultrices rutrum, nulla risus posuere ligula, et tincidunt erat augue quis ex. Cras bibendum rhoncus scelerisque. Duis vulputate id dolor sit amet tincidunt. Ut dictum orci vel mauris aliquam, sit amet malesuada massa interdum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc lobortis lacinia neque",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 4001,
                            Descricao = "Integer est sapien, convallis a feugiat quis, mattis in nisl. Integer eget odio non libero fringilla cursus tempor quis leo. Fusce rhoncus neque in ante cursus, vel placerat turpis dictum. Donec egestas aliquam lacus eget sollicitudin. Duis in posuere sapien. Vestibulum sodales tincidunt arcu id pretium. Vestibulum gravida nisi ut lorem tristique, posuere vulputate felis ultrices. Maecenas scelerisque, libero vitae efficitur malesuada, enim augue sodales nisl, vehicula volutpat sapien tortor in turpis. Etiam varius vulputate mi vitae tincidunt. Duis elementum et odio in dignissim. Integer in lectus vitae metus ultricies congue. Nulla pulvinar orci semper, placerat risus a, tincidunt diam. Ut condimentum dui eu erat tristique, ut mollis massa scelerisque. Suspendisse lacinia tortor in molestie mattis. Donec sed tempor ipsum. Sed non dui at lorem malesuada vehicula non eget tellus."
                        },
                        new Procedimento()
                        {
                            Identificador = 4002,
                            Descricao = "Nullam maximus facilisis mi, nec aliquam eros rhoncus sit amet. Suspendisse arcu lectus, suscipit eu ligula at, ultricies vehicula magna. Fusce ullamcorper fringilla ante, at sollicitudin dui eleifend rutrum. Phasellus in ipsum vitae neque sodales scelerisque vitae sit amet urna. Aliquam erat volutpat. Nulla ut diam sodales, iaculis lacus nec, euismod dolor. Vestibulum luctus tellus tempor, pellentesque orci at, condimentum nunc. Nam malesuada urna quis nunc dapibus ornare. Nam quis fringilla metus."
                        },
                        new Procedimento()
                        {
                            Identificador = 4003,
                            Descricao = "Cras sit amet mauris eu augue dapibus ultricies vitae feugiat augue. Nulla imperdiet tellus ut vehicula imperdiet. Aenean convallis dictum lacus non efficitur. Proin nec iaculis tortor, ut imperdiet urna. Nullam sollicitudin elementum mi, sit amet aliquam dolor ultrices suscipit. Proin ut dolor ac lacus interdum scelerisque et nec sapien. Cras consectetur consequat augue id eleifend. Pellentesque sed velit velit."
                        }

                    }
                },
                new ControleDeGovernanca()
                {
                    Identificador = 5,
                    Nome = "Controle 5",
                    Descricao = "Nulla non justo quis massa dapibus sollicitudin ac vel augue. Ut odio urna, feugiat id imperdiet quis, varius ut erat. Nulla id ultrices risus. Maecenas ut neque vitae diam semper tincidunt. Suspendisse vel blandit lacus. Proin auctor vehicula lacinia. Donec quis pretium purus. Integer pretium odio ex, quis auctor magna scelerisque id. Etiam erat purus, malesuada iaculis nisi malesuada, lacinia ultrices lectus. Nullam quis mi eu sem dictum elementum in non metus. Sed ac sem id augue vestibulum efficitur at vitae quam",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 5001,
                            Descricao = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin rutrum dignissim sapien, et pellentesque sem condimentum sed. Cras at orci non leo mattis pellentesque. Maecenas vitae vestibulum nisi, vel convallis enim. Vestibulum vitae arcu ipsum. Etiam tincidunt laoreet risus vel tristique. Curabitur id sapien mi. Vestibulum vehicula nibh suscipit hendrerit tempor. Etiam accumsan laoreet leo, non maximus augue. Proin lobortis nec justo ac congue. Sed feugiat placerat quam nec maximus. In nisi nibh, pulvinar eu aliquam sit amet, viverra vel diam. Curabitur non elit sed nunc consectetur dapibus. Donec eget porta elit. Sed eleifend luctus lectus, at efficitur leo."
                        },
                        new Procedimento()
                        {
                            Identificador = 5002,
                            Descricao = "Maecenas euismod euismod ante in volutpat. Proin lacus elit, faucibus in molestie et, ultricies et odio. Proin a nisi justo. Integer ullamcorper varius massa, id faucibus est varius in. Integer fermentum sollicitudin ullamcorper. Praesent consectetur fermentum justo. Cras non bibendum ligula. Nullam ullamcorper tortor ut semper placerat. Donec malesuada risus sit amet massa tristique pharetra. Cras luctus nisi sit amet purus aliquet, nec pretium massa lobortis."
                        },
                        new Procedimento()
                        {
                            Identificador = 5003,
                            Descricao = "Phasellus a vestibulum magna. Donec quis sodales est. Morbi faucibus ultrices dui, in auctor quam fringilla dapibus. In feugiat, velit ut egestas sodales, odio dolor mollis tortor, pellentesque pulvinar magna erat eu mauris. Duis aliquam feugiat hendrerit. In blandit et orci id congue. Sed urna mi, rhoncus et tortor a, egestas vehicula purus. Etiam velit mi, facilisis ac euismod ut, blandit ac urna. Praesent est sem, condimentum ut dictum quis, pharetra ac felis. Mauris porttitor viverra pretium. Nulla eleifend purus sed nibh luctus, vitae mollis nunc viverra. Maecenas a bibendum urna, non fringilla diam."
                        },
                        new Procedimento()
                        {
                            Identificador = 5004,
                            Descricao = "Integer eget diam nulla. Nunc eu est vehicula, sodales lorem id, efficitur lectus. Nullam sit amet commodo odio. Nunc sapien nunc, accumsan a euismod nec, aliquam ut dolor. Aliquam efficitur, dui non aliquet interdum, urna leo scelerisque velit, at sagittis dui nibh gravida ante. In risus quam, mattis eu mi congue, ultrices commodo augue. Aenean orci magna, pulvinar a turpis et, scelerisque pretium sem. Suspendisse eu velit ut massa tincidunt imperdiet. Donec consectetur ultrices nunc."
                        }
                    }
                },
                new ControleDeGovernanca()
                {
                    Identificador = 6,
                    Nome = "Controle 6",
                    Descricao = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In laoreet nunc sit amet turpis egestas, a feugiat magna efficitur. Sed malesuada eu purus eget semper. Proin gravida id risus gravida sollicitudin. Donec ultricies est rhoncus lectus tincidunt, at volutpat lorem vehicula. Pellentesque auctor lorem ut justo cursus, sed posuere nisl bibendum. Aenean interdum sollicitudin neque id pharetra. Sed at nunc sit amet nunc faucibus eleifend et a erat. Integer sit amet ex in ante mattis iaculis id id diam. Etiam commodo tempus mi, in mollis magna faucibus at. Vestibulum efficitur sed dui pulvinar dictum. Sed volutpat libero vel ligula dignissim mollis. Fusce malesuada cursus tristique. Phasellus sed justo eget justo convallis finibus. Suspendisse mattis quam id ullamcorper tempus",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 6001,
                            Descricao = "Pellentesque tristique eros vitae eros vehicula scelerisque. Proin scelerisque vel lorem sed viverra. Duis porttitor augue sed luctus lacinia. Sed lorem erat, venenatis at efficitur et, fringilla vel velit. Morbi arcu turpis, vehicula vitae eros in, rutrum convallis nibh. Maecenas tempor purus at elit luctus imperdiet. Morbi nec suscipit felis, eu aliquam arcu. Vivamus cursus rhoncus pellentesque. Phasellus nec velit in eros mollis fringilla. Sed at dignissim nunc. Nullam cursus ac libero at efficitur."
                        },
                        new Procedimento()
                        {
                            Identificador = 6002,
                            Descricao = "Donec sit amet pretium mi, ac tempor purus. Proin semper turpis in massa aliquam congue. Nam tristique placerat ipsum ut scelerisque. Sed sem dolor, viverra nec sagittis ut, ornare at nibh. Duis quis ultrices tellus. Etiam ultricies aliquam pulvinar. Quisque venenatis sem eros, sed accumsan lorem mattis finibus. In varius lorem ligula, nec vestibulum metus rutrum vel. Ut et faucibus elit. Ut in nulla mauris. Pellentesque sapien nibh, malesuada at justo in, mollis finibus nisl. Vivamus sed commodo magna. Curabitur in tristique augue. Nunc commodo egestas massa, eu rutrum ligula porttitor eget."
                        }
                    }
                }
            };

            return resultado.Where(
                n =>
                String.IsNullOrWhiteSpace(filtro) ||
                n.Nome.ToLower().Contains(filtro) ||
                n.Descricao.ToLower().Contains(filtro)
            );
        }
    }
}
