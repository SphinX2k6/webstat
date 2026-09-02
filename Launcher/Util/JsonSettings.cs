using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpScript.Launcher.Util.Json;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044A2 RID: 17570
	public class JsonSettings : IStaticVariableResetter
	{
		// Token: 0x0602E540 RID: 189760 RVA: 0x00AE0378 File Offset: 0x00ADE578
		static JsonSettings()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(JsonSettings.CreateStaticDefaultValue), new Action(JsonSettings.ResetStaticDefaultValue));
		}

		// Token: 0x0602E541 RID: 189761 RVA: 0x00AE0397 File Offset: 0x00ADE597
		public static void CreateStaticDefaultValue()
		{
			JsonSerializerOptions options = LauncherJsonSettings.CreateOptions(JsonIgnoreCondition.WhenWritingNull);
			JsonSettings.EncodeOptions = LauncherJsonSettings.CreateOptionsWithMarkerConverters(options);
			JsonSettings.DecodeOptions = LauncherJsonSettings.CreateOptionsWithMarkerConverters(options);
		}

		// Token: 0x0602E542 RID: 189762 RVA: 0x00AE03B4 File Offset: 0x00ADE5B4
		public static void ResetStaticDefaultValue()
		{
			JsonSettings.EncodeOptions = null;
			JsonSettings.DecodeOptions = null;
		}

		// Token: 0x0401A4FF RID: 107775
		[Nullable(2)]
		public static JsonSerializerOptions EncodeOptions;

		// Token: 0x0401A500 RID: 107776
		[Nullable(2)]
		public static JsonSerializerOptions DecodeOptions;
	}
}
