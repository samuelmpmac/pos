using Mock.GestaoDeNormas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mock.GestaoDeNormas.Repositorios
{
    public class RepositorioDeNormas
    {
        public Norma ObterPeloIdentificador(Int32 identificador)
        {
            return ObterTodos().SingleOrDefault(n => n.Identificador == identificador);
        }

        public Norma ObterPeloGrupo(String grupo)
        {
            return ObterTodos().SingleOrDefault(n => n.Grupo.ToLower() == grupo.ToLower());
        }

        public IEnumerable<Norma> ObterTodos(String filtro = null)
        {
            var normas = new List<Norma>()
            {
                new Norma()
                {
                    Identificador = 1001,
                    Nome = "Norma 1001",
                    Grupo = "ABNT/ISO",
                    Descricao = "Fusce lectus risus, malesuada scelerisque risus eget, imperdiet consectetur felis. Nulla in odio id risus volutpat luctus ac ornare nulla. Aenean placerat diam justo, eu elementum quam dapibus et. Mauris iaculis tortor quis hendrerit molestie. Aenean tellus tellus, facilisis quis tortor ac, posuere eleifend erat. Mauris dapibus, ipsum sit amet fermentum blandit, massa massa faucibus diam, et vulputate lectus quam ut orci. Suspendisse dignissim velit et interdum tincidunt. Vivamus tristique lorem ligula. Sed volutpat laoreet nisi, sed fringilla est tincidunt vel. Proin ipsum ligula, cursus nec egestas et, varius sed ipsum. Sed rutrum ipsum vitae sem interdum ullamcorper. Maecenas at risus a risus vestibulum consectetur eget vel lorem. Mauris diam ipsum, hendrerit sed tempor id, aliquam in justo. Sed ex velit, ultricies vitae semper in, molestie vel velit.",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 11001,
                            Descricao = "Donec maximus turpis ut velit porttitor, id rutrum erat rhoncus. Mauris euismod interdum cursus. Quisque ac diam non arcu molestie commodo egestas quis elit. Duis varius ex eget sagittis ornare. Pellentesque ac lectus placerat, efficitur nibh gravida, tristique nisi. Sed in justo sed nulla consequat egestas sit amet quis dolor. Quisque consectetur vehicula arcu, vel condimentum lectus cursus ac. Nunc auctor convallis velit, sed pretium leo commodo eu. Mauris suscipit ipsum vitae turpis aliquet finibus. Proin egestas, eros eget imperdiet facilisis, orci justo tempor magna, nec pellentesque nulla est a lectus. Mauris quis nulla turpis. Quisque sodales pretium ex, sit amet consectetur purus accumsan vitae. Donec volutpat diam eget tincidunt dictum."
                        },
                        new Procedimento()
                        {
                            Identificador = 11002,
                            Descricao = "Praesent id augue sollicitudin, interdum est non, volutpat lectus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Duis sed tincidunt velit, nec imperdiet quam. Mauris pellentesque tellus eu sapien vulputate rhoncus. Suspendisse fermentum venenatis felis, nec tempor eros aliquam sit amet. Etiam felis diam, interdum vitae ultrices mattis, vulputate sit amet mauris. Fusce ultrices mollis urna, et consequat purus vulputate imperdiet. Praesent a interdum dolor. Nullam volutpat erat et erat posuere, vitae lobortis libero vehicula. Ut quam nibh, maximus nec lorem id, laoreet consectetur ipsum. Aliquam vestibulum ipsum vel est tincidunt scelerisque. Integer et dictum neque."
                        },
                        new Procedimento()
                        {
                            Identificador = 11003,
                            Descricao = "Phasellus eleifend massa sed mi convallis tristique. Vestibulum dapibus elementum leo. Curabitur posuere velit eu tortor ultrices mollis. Mauris convallis dui enim, in gravida dui ultricies sed. Nunc aliquam eu libero ut porttitor. Sed imperdiet imperdiet tincidunt. Phasellus quam lorem, maximus vitae felis a, ultrices volutpat quam. Ut viverra nunc in justo suscipit imperdiet. Vivamus non lorem lectus. Quisque quam magna, interdum eu magna a, condimentum fringilla leo. Aenean finibus vulputate odio in molestie. Etiam fermentum ac ligula vitae facilisis. Proin rhoncus auctor turpis, non facilisis sapien convallis ut. Sed vulputate dictum dolor, sed eleifend nunc consequat ut. Fusce eget ipsum sit amet sapien faucibus elementum."
                        },
                        new Procedimento()
                        {
                            Identificador = 11004,
                            Descricao = "Etiam placerat consectetur dui eget vehicula. Nunc scelerisque dignissim lorem ut finibus. Suspendisse potenti. Curabitur ut magna sed enim consectetur luctus. Nulla facilisi. Cras eu bibendum eros. Sed sagittis euismod risus id sagittis. Praesent facilisis sit amet enim nec volutpat. Integer cursus et lacus sed pharetra. Nulla hendrerit volutpat magna, sodales facilisis dui placerat eu. Fusce dignissim ipsum ligula, a fermentum erat rhoncus at. Proin egestas dolor ut arcu convallis sodales. Nulla iaculis auctor nulla, ac faucibus sapien tempus ac. Vivamus nisl lectus, elementum ac elementum eu, dignissim vitae nisi."
                        }

                    }
                },
                new Norma()
                {
                    Identificador = 2002,
                    Nome = "Norma 2002",
                    Grupo = "ABNT/ISO",
                    Descricao = "Phasellus interdum sed sem eu fermentum. Curabitur luctus porta pellentesque. Praesent iaculis, sapien tempor malesuada interdum, ligula dui convallis ligula, non consequat mauris ante sed lorem. Fusce magna nunc, vehicula et aliquam sit amet, luctus ac nisi. Morbi fringilla lobortis nisl, fermentum semper ligula elementum nec. Fusce scelerisque dui sit amet malesuada euismod. Donec eu tincidunt eros. Donec iaculis lectus nec imperdiet mattis. In euismod ex at sapien consectetur iaculis. Maecenas quis viverra elit, at imperdiet urna. Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 22001,
                            Descricao = "Fusce sagittis, felis vel varius eleifend, justo erat laoreet mauris, a congue metus nibh vitae velit. Aliquam vulputate commodo nulla, vitae consequat mi. Cras in congue ante, ac imperdiet sem. Cras mollis accumsan pretium. Etiam at vestibulum mauris. Ut non lobortis mi. Morbi nec feugiat lectus. Sed in iaculis lorem. Fusce luctus ante vel vehicula laoreet."
                        },
                        new Procedimento()
                        {
                            Identificador = 22002,
                            Descricao = "Nunc dignissim quis ipsum vel varius. In venenatis neque ante, quis iaculis risus sollicitudin vitae. Donec gravida, justo in vestibulum viverra, sapien leo euismod massa, a vestibulum nisl ipsum sed ligula. Cras suscipit volutpat ligula, id semper dolor maximus et. Aliquam quis lorem eu elit scelerisque egestas. Aliquam mi nisl, ornare vel rutrum ut, pretium quis lacus. Aliquam erat volutpat. In auctor magna eu rhoncus aliquet. Donec sit amet erat congue, accumsan lorem eget, sollicitudin ligula."
                        },
                        new Procedimento()
                        {
                            Identificador = 22003,
                            Descricao = "Nulla auctor risus neque, non gravida mauris varius quis. In nec leo at leo faucibus consequat. Quisque consectetur placerat ante, nec vestibulum nisi tristique sit amet. Ut rutrum ac urna suscipit mollis. Nulla in ex sit amet nulla feugiat mollis vitae eu erat. Etiam vestibulum libero id urna dignissim, vel tincidunt ipsum porttitor. Vestibulum vulputate euismod sem, sit amet pharetra ligula scelerisque sit amet. Sed placerat eget sem non posuere. Proin hendrerit, dolor id convallis imperdiet, risus massa euismod lorem, nec commodo mauris risus faucibus purus. Nulla nibh mi, porttitor vel mi nec, vestibulum suscipit velit. Praesent vel lacus mollis, fermentum turpis sit amet, malesuada sem. Duis eu tortor dolor. Mauris urna orci, fermentum a elementum at, feugiat ut ipsum. Nam et sapien eget orci porttitor consectetur. Morbi venenatis, nunc ac pulvinar accumsan, orci erat imperdiet sapien, vitae gravida risus massa eu urna. Nunc orci arcu, interdum nec imperdiet ut, malesuada eget purus."
                        },
                        new Procedimento()
                        {
                            Identificador = 22004,
                            Descricao = "Cras rutrum dolor non varius facilisis. Integer nisl turpis, ornare pretium massa nec, efficitur rutrum justo. Cras nisi urna, rutrum eget sollicitudin dignissim, condimentum at felis. In hac habitasse platea dictumst. In lacinia velit vel quam maximus rutrum. Cras ac rutrum turpis. Nam sagittis tempor ullamcorper. Praesent ex ex, scelerisque a diam non, consequat rutrum urna."
                        }

                    }
                },
                new Norma()
                {
                    Identificador = 3003,
                    Nome = "Norma 3003",
                    Grupo = "IEEE",
                    Descricao = "Cras gravida magna orci, id sodales ex dictum et. Phasellus sodales fermentum egestas. Ut venenatis commodo diam, sagittis scelerisque mauris tristique eget. Ut porta convallis felis et congue. Aliquam imperdiet vel nunc sit amet fermentum. In suscipit dignissim magna, at faucibus lorem dignissim eget. Sed maximus nisl sit amet diam consequat condimentum. Ut ullamcorper ligula eu lacus sollicitudin euismod. Sed non sagittis lacus. Donec tincidunt diam vitae consectetur tempor. Nulla ligula purus, finibus eu condimentum eu, mollis a metus. Morbi euismod facilisis orci, non vestibulum tellus ultricies a. Morbi vel neque varius, rhoncus libero eu, imperdiet risus. Donec varius velit at neque accumsan aliquet.",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 33001,
                            Descricao = "Maecenas laoreet lectus consequat ipsum posuere, quis malesuada odio imperdiet. Maecenas sapien enim, auctor quis libero at, laoreet condimentum risus. Donec ultrices egestas tortor eu pulvinar. Sed vulputate, augue non pretium faucibus, metus felis tempus lorem, non bibendum diam sem ac massa. Vivamus venenatis nec mauris mollis tristique. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Praesent dui dolor, posuere vel molestie in, hendrerit id ante. Aenean tempor tincidunt elementum. Phasellus finibus libero vel facilisis semper. Nullam consequat mattis tortor, vitae viverra neque malesuada a. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut dignissim hendrerit quam, non porta est dignissim eu. Cras fringilla feugiat urna a sagittis. Proin mollis a turpis in finibus."
                        },
                        new Procedimento()
                        {
                            Identificador = 33002,
                            Descricao = "Donec nec dolor vitae arcu aliquam interdum id sit amet velit. Suspendisse quis purus nunc. Vestibulum fringilla tortor vitae mattis maximus. Fusce at tellus consectetur, lobortis magna convallis, condimentum enim. Nam condimentum purus quis augue semper dapibus. Phasellus semper, urna et feugiat condimentum, dui eros porta nisl, non hendrerit est nisi a sem. Vivamus ut egestas sem, et faucibus orci. Etiam eu sodales diam. Suspendisse ullamcorper imperdiet elit, maximus convallis massa lobortis sed. Vivamus ex ex, tincidunt quis libero sed, ultrices dignissim neque. Nunc condimentum lorem at porttitor semper. Nunc convallis sapien nulla, id interdum tellus sodales ut. Vivamus ante tellus, mollis non sagittis sed, vehicula et sapien. Donec nulla lacus, condimentum quis libero id, venenatis sagittis nunc."
                        }
                    }
                },
                new Norma()
                {
                    Identificador = 4004,
                    Nome = "Norma 4004",
                    Grupo = "IEEE",
                    Descricao = "Duis vestibulum dignissim interdum. Donec ac purus accumsan, mattis nisl at, congue ligula. Etiam sapien enim, tristique ac consectetur nec, vehicula efficitur leo. Pellentesque pellentesque eu metus id fermentum. Nulla sed dui non velit pharetra feugiat ut in eros. Ut auctor, libero sit amet ultrices rutrum, nulla risus posuere ligula, et tincidunt erat augue quis ex. Cras bibendum rhoncus scelerisque. Duis vulputate id dolor sit amet tincidunt. Ut dictum orci vel mauris aliquam, sit amet malesuada massa interdum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nunc lobortis lacinia neque",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 44001,
                            Descricao = "Integer est sapien, convallis a feugiat quis, mattis in nisl. Integer eget odio non libero fringilla cursus tempor quis leo. Fusce rhoncus neque in ante cursus, vel placerat turpis dictum. Donec egestas aliquam lacus eget sollicitudin. Duis in posuere sapien. Vestibulum sodales tincidunt arcu id pretium. Vestibulum gravida nisi ut lorem tristique, posuere vulputate felis ultrices. Maecenas scelerisque, libero vitae efficitur malesuada, enim augue sodales nisl, vehicula volutpat sapien tortor in turpis. Etiam varius vulputate mi vitae tincidunt. Duis elementum et odio in dignissim. Integer in lectus vitae metus ultricies congue. Nulla pulvinar orci semper, placerat risus a, tincidunt diam. Ut condimentum dui eu erat tristique, ut mollis massa scelerisque. Suspendisse lacinia tortor in molestie mattis. Donec sed tempor ipsum. Sed non dui at lorem malesuada vehicula non eget tellus."
                        },
                        new Procedimento()
                        {
                            Identificador = 44002,
                            Descricao = "Nullam maximus facilisis mi, nec aliquam eros rhoncus sit amet. Suspendisse arcu lectus, suscipit eu ligula at, ultricies vehicula magna. Fusce ullamcorper fringilla ante, at sollicitudin dui eleifend rutrum. Phasellus in ipsum vitae neque sodales scelerisque vitae sit amet urna. Aliquam erat volutpat. Nulla ut diam sodales, iaculis lacus nec, euismod dolor. Vestibulum luctus tellus tempor, pellentesque orci at, condimentum nunc. Nam malesuada urna quis nunc dapibus ornare. Nam quis fringilla metus."
                        },
                        new Procedimento()
                        {
                            Identificador = 44003,
                            Descricao = "Cras sit amet mauris eu augue dapibus ultricies vitae feugiat augue. Nulla imperdiet tellus ut vehicula imperdiet. Aenean convallis dictum lacus non efficitur. Proin nec iaculis tortor, ut imperdiet urna. Nullam sollicitudin elementum mi, sit amet aliquam dolor ultrices suscipit. Proin ut dolor ac lacus interdum scelerisque et nec sapien. Cras consectetur consequat augue id eleifend. Pellentesque sed velit velit."
                        }

                    }
                },
                new Norma()
                {
                    Identificador = 5005,
                    Nome = "Norma 5005",
                    Grupo = "ASTM",
                    Descricao = "Nulla facilisi. Sed rutrum ipsum rhoncus, efficitur libero et, vulputate felis. Aenean ultricies magna ipsum, tincidunt lacinia risus bibendum in. Nam tincidunt, leo quis facilisis elementum, urna mauris elementum augue, non ultrices orci ipsum ac velit. Fusce quis purus sit amet nulla vulputate sagittis a vel velit. Nam a pulvinar erat. Duis finibus nulla in arcu maximus, nec porttitor est malesuada. Sed ornare varius ligula sit amet porttitor. Vestibulum dapibus elit vel libero mollis, sed vehicula nunc malesuada. Duis scelerisque nibh interdum nisi iaculis, et volutpat dui finibus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Nulla aliquam nunc in est fringilla, ut tempor diam vulputate. Nullam gravida quis urna ut ornare. Sed hendrerit nunc dictum sapien sagittis semper nec id nisl.",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 55001,
                            Descricao = "Donec pharetra facilisis cursus. Donec et luctus nisi, quis aliquam sem. Aliquam ut mauris lorem. Sed scelerisque lectus sed quam pretium egestas. Fusce quis est pharetra, efficitur leo sit amet, feugiat nisi. Mauris massa leo, ornare sed ante id, auctor elementum felis. Donec elementum dapibus lectus, id vestibulum urna fermentum eget. Maecenas cursus elementum nisi, quis iaculis risus tempor et. Praesent a porta odio, nec posuere sem. Curabitur id aliquam elit, id vehicula leo. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed eget maximus felis. Ut suscipit felis id ex iaculis, et fermentum tortor consectetur. Nullam sed elementum velit. Aliquam imperdiet est vitae suscipit maximus. Duis maximus libero at euismod volutpat."
                        },
                        new Procedimento()
                        {
                            Identificador = 55002,
                            Descricao = "Suspendisse tincidunt commodo nulla ut tincidunt. Aenean a quam condimentum, pellentesque ipsum nec, vulputate nunc. Cras tempor diam accumsan commodo porta. Praesent pellentesque euismod risus, eu imperdiet ipsum congue non. Donec sed aliquet enim. Morbi in vehicula tellus. Quisque nec ultrices mauris. Fusce eleifend pulvinar orci a tincidunt."
                        },
                        new Procedimento()
                        {
                            Identificador = 55003,
                            Descricao = "Praesent vitae quam imperdiet, vehicula dolor vitae, sodales enim. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam et ullamcorper leo. Pellentesque ac tortor et sapien pulvinar tempor. In consequat in sapien nec dignissim. Praesent mattis, enim et euismod ultricies, lacus nisi semper tellus, vel commodo turpis nulla non nisi. Vestibulum sodales finibus neque non sollicitudin. Integer scelerisque malesuada orci quis tempus. Phasellus at convallis est. Duis in hendrerit sem, eget iaculis est. Nulla sagittis, arcu nec posuere rhoncus, tortor lectus ultricies eros, ac ultrices felis risus eu tellus. Aenean sed lectus consequat, pretium lorem sed, auctor eros. Maecenas commodo in quam ut mattis. Aenean feugiat dui eleifend mauris congue, eu cursus felis molestie."
                        },
                        new Procedimento()
                        {
                            Identificador = 55004,
                            Descricao = "Maecenas euismod euismod ante in volutpat. Proin lacus elit, faucibus in molestie et, ultricies et odio. Proin a nisi justo. Integer ullamcorper varius massa, id faucibus est varius in. Integer fermentum sollicitudin ullamcorper. Praesent consectetur fermentum justo. Cras non bibendum ligula. Nullam ullamcorper tortor ut semper placerat. Donec malesuada risus sit amet massa tristique pharetra. Cras luctus nisi sit amet purus aliquet, nec pretium massa lobortis."
                        }
                    }
                },
                new Norma()
                {
                    Identificador = 6006,
                    Nome = "Norma 6006",
                    Grupo = "ASTM",
                    Descricao = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In laoreet nunc sit amet turpis egestas, a feugiat magna efficitur. Sed malesuada eu purus eget semper. Proin gravida id risus gravida sollicitudin. Donec ultricies est rhoncus lectus tincidunt, at volutpat lorem vehicula. Pellentesque auctor lorem ut justo cursus, sed posuere nisl bibendum. Aenean interdum sollicitudin neque id pharetra. Sed at nunc sit amet nunc faucibus eleifend et a erat. Integer sit amet ex in ante mattis iaculis id id diam. Etiam commodo tempus mi, in mollis magna faucibus at. Vestibulum efficitur sed dui pulvinar dictum. Sed volutpat libero vel ligula dignissim mollis. Fusce malesuada cursus tristique. Phasellus sed justo eget justo convallis finibus. Suspendisse mattis quam id ullamcorper tempus",
                    Procedimentos = new List<Procedimento>()
                    {
                        new Procedimento()
                        {
                            Identificador = 66001,
                            Descricao = "Cras sit amet mauris eu augue dapibus ultricies vitae feugiat augue. Nulla imperdiet tellus ut vehicula imperdiet. Aenean convallis dictum lacus non efficitur. Proin nec iaculis tortor, ut imperdiet urna. Nullam sollicitudin elementum mi, sit amet aliquam dolor ultrices suscipit. Proin ut dolor ac lacus interdum scelerisque et nec sapien. Cras consectetur consequat augue id eleifend. Pellentesque sed velit velit."
                        },
                        new Procedimento()
                        {
                            Identificador = 66002,
                            Descricao = "Nullam maximus facilisis mi, nec aliquam eros rhoncus sit amet. Suspendisse arcu lectus, suscipit eu ligula at, ultricies vehicula magna. Fusce ullamcorper fringilla ante, at sollicitudin dui eleifend rutrum. Phasellus in ipsum vitae neque sodales scelerisque vitae sit amet urna. Aliquam erat volutpat. Nulla ut diam sodales, iaculis lacus nec, euismod dolor. Vestibulum luctus tellus tempor, pellentesque orci at, condimentum nunc. Nam malesuada urna quis nunc dapibus ornare. Nam quis fringilla metus."
                        }
                    }
                }
            };

            return normas.Where(
                    n =>
                    String.IsNullOrWhiteSpace(filtro) ||
                    n.Nome.ToLower().Contains(filtro) ||
                    n.Grupo.ToLower().Contains(filtro) || 
                    n.Descricao.ToLower().Contains(filtro)
                );
        }
    }
}
