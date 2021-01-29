namespace TrueColors.Util
{
    public interface IConverter<in Source, out Target>
    {
        Target Convert(Source source);
    }
}