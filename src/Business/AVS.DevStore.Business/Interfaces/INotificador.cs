using AVS.DevStore.Business.Notificacoes;

namespace AVS.DevStore.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}