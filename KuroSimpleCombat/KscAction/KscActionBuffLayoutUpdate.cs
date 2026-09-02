using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.KuroSimpleCombat;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D4 RID: 17364
	[NullableContext(1)]
	[Nullable(0)]
	public class KscActionBuffLayoutUpdate : KscActionBase
	{
		// Token: 0x0602E266 RID: 189030 RVA: 0x00ADA17F File Offset: 0x00AD837F
		public KscActionBuffLayoutUpdate(SimpleCombatEntityBuffLayerCountNotify params_) : base(params_.EntityId)
		{
			this.Params = params_;
		}

		// Token: 0x0602E267 RID: 189031 RVA: 0x00ADA194 File Offset: 0x00AD8394
		protected override UniTask RunContent()
		{
			KscActionBuffLayoutUpdate.<RunContent>d__2 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionBuffLayoutUpdate.<RunContent>d__2>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0602E268 RID: 189032 RVA: 0x00ADA1D8 File Offset: 0x00AD83D8
		private unsafe void ModifyBuffLayoutAsync(int kscEntityId)
		{
			int buffId = this.Params.BuffId;
			int layerCount = this.Params.LayerCount;
			KscEntityHandle kscEntityHandle;
			if (!this.KscCtrl.CurSubModel.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) || !kscEntityHandle.Valid)
			{
				KscLog.EModule flag = KscLog.EModule.Skill;
				string log = "刷新buff Layout时失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", kscEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Params", this.Params);
				base.Warn(flag, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.SetResult();
				return;
			}
			KSCBuff? kscbuff;
			string path = (ConfigKSCBuffById.GetConfig(buffId, true) != null) ? kscbuff.GetValueOrDefault().AssetPath : null;
			if (string.IsNullOrEmpty(path))
			{
				KscLog.EModule flag2 = KscLog.EModule.Skill;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Buff Layout时 ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(buffId);
				defaultInterpolatedStringHandler.AppendLiteral("安全加载路径非法");
				string log2 = defaultInterpolatedStringHandler.ToStringAndClear();
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Params", this.Params);
				base.Warn(flag2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.SetResult();
				return;
			}
			KscLog.EModule flag3 = KscLog.EModule.Load;
			string log3 = "战斗实体安全加载Buff开始";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("buffId", buffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("path", path);
			base.Debug(flag3, log3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			LoadAssetParams<UKSC_DA_Buff> loadAssetParams = new LoadAssetParams<UKSC_DA_Buff>();
			loadAssetParams.Context = Singleton<KscEnv>.Instance.KscWorld;
			loadAssetParams.Id = buffId;
			loadAssetParams.Path = path;
			UKSC_World kscWorld = Singleton<KscEnv>.Instance.KscWorld;
			loadAssetParams.NativeContainer = ((kscWorld != null) ? kscWorld.LoadedBuffDa : null);
			loadAssetParams.Callback = delegate(UKSC_DA_Buff resultAsset)
			{
				if (!this.KscCtrl.WorldInit)
				{
					this.Warn(KscLog.EModule.Load, "战斗实体加载失败，KSC世界已清理", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.SetResult();
					return;
				}
				KscActionBase <>4__this = this;
				KscLog.EModule flag4 = KscLog.EModule.Skill;
				string log4 = "更新Buff";
				<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray4<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("kscEntityHandle", kscEntityHandle);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("buffId", buffId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("layerCount", layerCount);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("path", path);
				<>4__this.Debug(flag4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				kscEntityHandle.KscEntity.UpdateBuffWithStackNumSelf(resultAsset, layerCount);
				this.SetResult();
			};
			loadAssetParams.FailCallback = delegate(string error)
			{
				KscActionBase <>4__this = this;
				KscLog.EModule flag4 = KscLog.EModule.Skill;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler2 = new DefaultInterpolatedStringHandler(30, 1);
				defaultInterpolatedStringHandler2.AppendLiteral("添加buff Layout时失败,未查到资产,BuffId:");
				defaultInterpolatedStringHandler2.AppendFormatted<int>(buffId);
				string log4 = defaultInterpolatedStringHandler2.ToStringAndClear();
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Params", this.Params);
				<>4__this.Warn(flag4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				this.SetResult();
			};
			loadAssetParams.KscWorldHandle = Singleton<KscEnv>.Instance.KscWorldHandle;
			KscUtil.AsyncLoadKscAsset<UKSC_DA_Buff>(loadAssetParams);
		}

		// Token: 0x0401A1A2 RID: 106914
		public SimpleCombatEntityBuffLayerCountNotify Params;
	}
}
