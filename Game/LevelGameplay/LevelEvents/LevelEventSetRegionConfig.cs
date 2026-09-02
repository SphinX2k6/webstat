using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;
using AkiClient.Game.Aki.Render.RuntimeBP.RenderData;
using CSharpScript.Game.Render;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006BEE RID: 27630
	public class LevelEventSetRegionConfig : LevelEventBase
	{
		// Token: 0x060440F5 RID: 278773 RVA: 0x011AAE7C File Offset: 0x011A907C
		public LevelEventSetRegionConfig(int id) : base(id)
		{
		}

		// Token: 0x060440F6 RID: 278774 RVA: 0x011AAE88 File Offset: 0x011A9088
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			SetRegionConfig setRegionConfig = inParams as SetRegionConfig;
			if (setRegionConfig.Type != ERegionConfigType.Mpc)
			{
				base.FinishExecute(true, false, true);
				return;
			}
			AreaMpc? config = ConfigAreaMpcById.GetConfig((setRegionConfig as ISetRegionMpc).RegionMpcId, true);
			string mpcData = config.Value.MpcData;
			if (string.IsNullOrEmpty(mpcData) || mpcData == "None" || mpcData == "Empty")
			{
				global::Log instance = Singleton<global::Log>.Instance;
				ELogModule module = ELogModule.LevelEvent;
				ELogAuthor author = ELogAuthor.YZH;
				string message = "[SetRegionConfig]未配置对应区域的MPCData";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("AreaId", config.Value.RegionId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("MpcData", mpcData);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.FinishExecute(true, false, true);
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<ItemMaterialControllerMPCData_C>(mpcData, delegate([Nullable(2)] ItemMaterialControllerMPCData_C data, string _)
			{
				if (data == null || !data.IsValid())
				{
					Singleton<global::Log>.Instance.Error(ELogModule.LevelEvent, ELogAuthor.YZH, "[SetRegionConfig]: MPCData无效", default(ReadOnlySpan<ValueTuple<string, object>>));
					base.FinishExecute(true, false, true);
					return;
				}
				ModelBase<RenderModuleModel>.Instance.UpdateItemMaterialParameterCollection(data);
				base.FinishExecute(true, false, true);
			}, 100, "js_undefined");
		}
	}
}
