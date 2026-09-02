using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.KuroSimpleCombat;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D5 RID: 17365
	public class KscActionBuffModifyLocal : KscActionBase
	{
		// Token: 0x0602E269 RID: 189033 RVA: 0x00ADA413 File Offset: 0x00AD8613
		public KscActionBuffModifyLocal(long creatureId, int kscEntityId, bool isAdd, int buffId) : base(creatureId)
		{
			this.KscEntityId = kscEntityId;
			this.IsAdd = isAdd;
			this.BuffId = buffId;
		}

		// Token: 0x0602E26A RID: 189034 RVA: 0x00ADA434 File Offset: 0x00AD8634
		protected override UniTask RunContent()
		{
			KscActionBuffModifyLocal.<RunContent>d__4 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionBuffModifyLocal.<RunContent>d__4>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0602E26B RID: 189035 RVA: 0x00ADA478 File Offset: 0x00AD8678
		private unsafe void ModifyBuffAsync(int kscEntityId)
		{
			bool isAdd = this.IsAdd;
			int buffId = this.BuffId;
			KscEntityHandle kscEntityHandle;
			if (!this.KscCtrl.CurSubModel.KscEntities.TryGetValue(kscEntityId, out kscEntityHandle) || !kscEntityHandle.Valid)
			{
				KscLog.EModule flag = KscLog.EModule.Skill;
				string log = "刷新buff时失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", kscEntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("buffId", this.BuffId);
				base.Warn(flag, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.SetResult();
				return;
			}
			KSCBuff? kscbuff;
			string path = (ConfigKSCBuffById.GetConfig(buffId, true) != null) ? kscbuff.GetValueOrDefault().AssetPath : null;
			if (string.IsNullOrEmpty(path))
			{
				KscLog.EModule flag2 = KscLog.EModule.Skill;
				string log2 = "Buff路径非法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("buffId", buffId);
				base.Error(flag2, log2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
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
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 2) = new ValueTuple<string, object>("IsAdd", isAdd);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 3) = new ValueTuple<string, object>("path", path);
				<>4__this.Debug(flag4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 4));
				UKSC_World kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
				if (kscWorld2 != null)
				{
					UKSC_BuffId buffData = kscWorld2.BuffData;
					if (buffData != null)
					{
						buffData.AddBuffDA((long)buffId, resultAsset);
					}
				}
				if (isAdd)
				{
					kscEntityHandle.KscEntity.ApplyBuffSelf(resultAsset);
				}
				else
				{
					kscEntityHandle.KscEntity.RemoveBuffSelf(resultAsset);
				}
				this.SetResult();
			};
			loadAssetParams.FailCallback = delegate(string error)
			{
				KscActionBase <>4__this = this;
				KscLog.EModule flag4 = KscLog.EModule.Skill;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
				defaultInterpolatedStringHandler.AppendLiteral("添加buff失败,未查到资产,BuffId:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(buffId);
				<>4__this.Warn(flag4, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.SetResult();
			};
			loadAssetParams.KscWorldHandle = Singleton<KscEnv>.Instance.KscWorldHandle;
			KscUtil.AsyncLoadKscAsset<UKSC_DA_Buff>(loadAssetParams);
		}

		// Token: 0x0401A1A3 RID: 106915
		public int KscEntityId;

		// Token: 0x0401A1A4 RID: 106916
		public bool IsAdd;

		// Token: 0x0401A1A5 RID: 106917
		public int BuffId;
	}
}
