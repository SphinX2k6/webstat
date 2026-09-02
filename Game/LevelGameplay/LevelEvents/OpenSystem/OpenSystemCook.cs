using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents.OpenSystem
{
	// Token: 0x02006C45 RID: 27717
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenSystemCook : OpenSystemBase
	{
		// Token: 0x06044221 RID: 279073 RVA: 0x011B142D File Offset: 0x011AF62D
		public OpenSystemCook(LevelEventOpenSystem eventBase)
		{
			Dictionary<int, EUiViewName> dictionary = new Dictionary<int, EUiViewName>();
			dictionary[0] = EUiViewName.CookRootView;
			dictionary[1] = EUiViewName.CookMechanismRootView;
			dictionary[2] = EUiViewName.CookSchoolMechanismRootView;
			this.CookViewMap = dictionary;
			base..ctor(eventBase);
		}

		// Token: 0x06044222 RID: 279074 RVA: 0x011B1468 File Offset: 0x011AF668
		[return: Nullable(0)]
		public override UniTask<bool> ExecuteOpenView(OpenSystemBoard inParams, GeneralContext context)
		{
			OpenSystemCook.<ExecuteOpenView>d__2 <ExecuteOpenView>d__;
			<ExecuteOpenView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<ExecuteOpenView>d__.<>4__this = this;
			<ExecuteOpenView>d__.inParams = inParams;
			<ExecuteOpenView>d__.<>1__state = -1;
			<ExecuteOpenView>d__.<>t__builder.Start<OpenSystemCook.<ExecuteOpenView>d__2>(ref <ExecuteOpenView>d__);
			return <ExecuteOpenView>d__.<>t__builder.Task;
		}

		// Token: 0x06044223 RID: 279075 RVA: 0x011B14B4 File Offset: 0x011AF6B4
		[NullableContext(2)]
		public override EUiViewName? GetViewName(OpenSystemBoard inParams = null, GeneralContext context = null)
		{
			if (inParams == null)
			{
				return new EUiViewName?(EUiViewName.CookRootView);
			}
			EUiViewName value;
			if (this.CookViewMap.TryGetValue(inParams.BoardId, out value))
			{
				return new EUiViewName?(value);
			}
			return new EUiViewName?(EUiViewName.CookRootView);
		}

		// Token: 0x040260A8 RID: 155816
		private readonly Dictionary<int, EUiViewName> CookViewMap;
	}
}
