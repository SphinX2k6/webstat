using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Effect;
using CSharpScript.Game.KuroSimpleCombat;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace KuroSimpleCombat.KscAction
{
	// Token: 0x020043D8 RID: 17368
	[NullableContext(1)]
	[Nullable(0)]
	public class KscActionEntityAdd : KscActionBase
	{
		// Token: 0x0602E272 RID: 189042 RVA: 0x00ADA9BB File Offset: 0x00AD8BBB
		public KscActionEntityAdd(IKscEntityParam params_) : base(params_.CreatureId)
		{
			this.Params = params_;
		}

		// Token: 0x0602E273 RID: 189043 RVA: 0x00ADA9D0 File Offset: 0x00AD8BD0
		protected override void CancelContent()
		{
			if (this.WarningTimerHandle != null)
			{
				TimerSystem.Instance.Remove(this.WarningTimerHandle);
				this.WarningTimerHandle = null;
			}
			this.StopWarningEffect();
			UniTaskCompletionSource warningPromise = this.WarningPromise;
			if (warningPromise == null)
			{
				return;
			}
			warningPromise.TrySetResult();
		}

		// Token: 0x0602E274 RID: 189044 RVA: 0x00ADAA0C File Offset: 0x00AD8C0C
		protected override UniTask RunContent()
		{
			KscActionEntityAdd.<RunContent>d__6 <RunContent>d__;
			<RunContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunContent>d__.<>4__this = this;
			<RunContent>d__.<>1__state = -1;
			<RunContent>d__.<>t__builder.Start<KscActionEntityAdd.<RunContent>d__6>(ref <RunContent>d__);
			return <RunContent>d__.<>t__builder.Task;
		}

		// Token: 0x0602E275 RID: 189045 RVA: 0x00ADAA50 File Offset: 0x00AD8C50
		private unsafe void LoadKscAssetCallback(UKSC_DA_Entity resultAsset)
		{
			if (!this.KscCtrl.WorldInit)
			{
				base.Warn(KscLog.EModule.Load, "战斗实体加载失败，KSC世界已清理", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.SetResult();
				return;
			}
			if (resultAsset == null || !resultAsset.IsValid())
			{
				KscLog.EModule flag = KscLog.EModule.Load;
				string log = "战斗实体加载失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", this.Params.AssetPath);
				base.Warn(flag, log, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.SetResult();
				return;
			}
			if (this.IsCancel)
			{
				KscLog.EModule flag2 = KscLog.EModule.Load;
				string log2 = "战斗实体加载完成任务被取消";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", this.EntityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Class", base.GetType().Name);
				base.Warn(flag2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				base.SetResult();
				return;
			}
			KscLog.EModule flag3 = KscLog.EModule.Load;
			string log3 = "生成战斗实体时加载成功";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Path", this.Params.AssetPath);
			base.Debug(flag3, log3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.AddEntitySafe(resultAsset, this.Params).Then(delegate(AKSC_Entity kscEntity)
			{
				KscLog.EModule flag4 = KscLog.EModule.Load;
				string log4 = "安全加入战斗实体";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Path", this.Params.AssetPath);
				base.Debug(flag4, log4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				if (this.Params.FinishCallback != null && kscEntity != null)
				{
					this.Params.FinishCallback(kscEntity);
				}
			}).Finally(new Action(base.SetResult)).Forget(delegate(Exception error)
			{
				KscLog.EModule flag4 = KscLog.EModule.Load;
				string log4 = "安全加入战斗实体失败";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Path", this.Params.AssetPath);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("reason", error.Message);
				base.Warn(flag4, log4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}, true);
		}

		// Token: 0x0602E276 RID: 189046 RVA: 0x00ADAB9C File Offset: 0x00AD8D9C
		private void LoadKscAssetFailCallback(string error)
		{
			base.SetResult();
		}

		// Token: 0x0602E277 RID: 189047 RVA: 0x00ADABA4 File Offset: 0x00AD8DA4
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<AKSC_Entity> AddEntitySafe(UKSC_DA_Entity asset, IKscEntityParam params_)
		{
			KscActionEntityAdd.<AddEntitySafe>d__9 <AddEntitySafe>d__;
			<AddEntitySafe>d__.<>t__builder = AsyncUniTaskMethodBuilder<AKSC_Entity>.Create();
			<AddEntitySafe>d__.<>4__this = this;
			<AddEntitySafe>d__.asset = asset;
			<AddEntitySafe>d__.params_ = params_;
			<AddEntitySafe>d__.<>1__state = -1;
			<AddEntitySafe>d__.<>t__builder.Start<KscActionEntityAdd.<AddEntitySafe>d__9>(ref <AddEntitySafe>d__);
			return <AddEntitySafe>d__.<>t__builder.Task;
		}

		// Token: 0x0602E278 RID: 189048 RVA: 0x00ADABF8 File Offset: 0x00AD8DF8
		private UniTask PlayAppearWarning(UKSC_DA_Entity asset, IKscEntityParam params_)
		{
			KscActionEntityAdd.<PlayAppearWarning>d__10 <PlayAppearWarning>d__;
			<PlayAppearWarning>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayAppearWarning>d__.<>4__this = this;
			<PlayAppearWarning>d__.asset = asset;
			<PlayAppearWarning>d__.params_ = params_;
			<PlayAppearWarning>d__.<>1__state = -1;
			<PlayAppearWarning>d__.<>t__builder.Start<KscActionEntityAdd.<PlayAppearWarning>d__10>(ref <PlayAppearWarning>d__);
			return <PlayAppearWarning>d__.<>t__builder.Task;
		}

		// Token: 0x0602E279 RID: 189049 RVA: 0x00ADAC4B File Offset: 0x00AD8E4B
		private void StopWarningEffect()
		{
			if (this.WarningEffectId != 0)
			{
				Singleton<EffectSystem>.Instance.StopEffectById(this.WarningEffectId, "KSC_AppearWarning_Stop", true, new bool?(true));
				this.WarningEffectId = 0;
			}
		}

		// Token: 0x0401A1A8 RID: 106920
		public IKscEntityParam Params;

		// Token: 0x0401A1A9 RID: 106921
		[Nullable(2)]
		private UniTaskCompletionSource WarningPromise;

		// Token: 0x0401A1AA RID: 106922
		[Nullable(2)]
		private TimerHandle WarningTimerHandle;

		// Token: 0x0401A1AB RID: 106923
		private int WarningEffectId;
	}
}
