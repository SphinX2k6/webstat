using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Level;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball
{
	// Token: 0x02006591 RID: 26001
	public class PinballViewDefine : IStaticVariableResetter
	{
		// Token: 0x06040F7F RID: 266111 RVA: 0x010AB51E File Offset: 0x010A971E
		static PinballViewDefine()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(PinballViewDefine.CreateStaticDefaultValue), new Action(PinballViewDefine.ResetStaticDefaultValue));
		}

		// Token: 0x06040F80 RID: 266112 RVA: 0x010AB540 File Offset: 0x010A9740
		public static void CreateStaticDefaultValue()
		{
			Dictionary<string, ValueTuple<Func<PinballMainChildViewBase>, string>> dictionary = new Dictionary<string, ValueTuple<Func<PinballMainChildViewBase>, string>>();
			dictionary["PinballMainView"] = new ValueTuple<Func<PinballMainChildViewBase>, string>(() => new PinballMainView(), "UiView_PinballMain");
			dictionary["PinballLevelView"] = new ValueTuple<Func<PinballMainChildViewBase>, string>(() => new PinballLevelView(), "UiView_PinballLevel");
			dictionary["PinballTowerLevelView"] = new ValueTuple<Func<PinballMainChildViewBase>, string>(() => new PinballTowerLevelView(), "UiView_PinballTowerLevel");
			dictionary["PinballDailyLevelView"] = new ValueTuple<Func<PinballMainChildViewBase>, string>(() => new PinballDailyLevelView(), "UiView_PinballDailyLevel");
			PinballViewDefine.pinballMainChildViewCreateInfo = dictionary;
		}

		// Token: 0x06040F81 RID: 266113 RVA: 0x010AB627 File Offset: 0x010A9827
		public static void ResetStaticDefaultValue()
		{
			PinballViewDefine.pinballMainChildViewCreateInfo = null;
		}

		// Token: 0x0402470D RID: 149261
		[Nullable(new byte[]
		{
			2,
			1,
			0,
			1,
			1,
			1
		})]
		public static Dictionary<string, ValueTuple<Func<PinballMainChildViewBase>, string>> pinballMainChildViewCreateInfo;
	}
}
