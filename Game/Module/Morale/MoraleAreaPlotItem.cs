using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.UI.View.Morale;
using CSharpScript.Game.Module.Morale.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005701 RID: 22273
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleAreaPlotItem : UiPanelBase
	{
		// Token: 0x06038AE1 RID: 232161 RVA: 0x00E5A778 File Offset: 0x00E58978
		[NullableContext(1)]
		public UniTask Init(UUIItem item, MoraleAreaPlotData plotData)
		{
			MoraleAreaPlotItem.<Init>d__7 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.plotData = plotData;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleAreaPlotItem.<Init>d__7>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038AE2 RID: 232162 RVA: 0x00E5A7CC File Offset: 0x00E589CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06038AE3 RID: 232163 RVA: 0x00E5A878 File Offset: 0x00E58A78
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleAreaPlotItem.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleAreaPlotItem.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038AE4 RID: 232164 RVA: 0x00E5A8BB File Offset: 0x00E58ABB
		public void SetPlotActive(bool active)
		{
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x06038AE5 RID: 232165 RVA: 0x00E5A8CF File Offset: 0x00E58ACF
		public void UpdatePlotState()
		{
			this.SetPlotActive(this.GetPlotIsActive());
		}

		// Token: 0x06038AE6 RID: 232166 RVA: 0x00E5A8E0 File Offset: 0x00E58AE0
		public bool GetPlotIsActive()
		{
			int flagId = this.PlotData.FlagId;
			int areaId = this.PlotData.AreaId;
			MoraleAreaData areaData = ModelBase<MoraleModel>.Instance.GetAreaData(areaId);
			MoraleAreaFlagData moraleAreaFlagData = (areaData != null) ? areaData.GetFlag(flagId) : null;
			return moraleAreaFlagData != null && moraleAreaFlagData.IsActive;
		}

		// Token: 0x06038AE7 RID: 232167 RVA: 0x00E5A929 File Offset: 0x00E58B29
		public void SetPlotLight(bool active)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(active);
		}

		// Token: 0x06038AE8 RID: 232168 RVA: 0x00E5A93D File Offset: 0x00E58B3D
		public void SetPlotLightAlpha(float alpha)
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(alpha);
		}

		// Token: 0x06038AE9 RID: 232169 RVA: 0x00E5A951 File Offset: 0x00E58B51
		public void SetPlotNewUnlock(bool active)
		{
			UUINiagara uiNiagara = base.GetUiNiagara(3);
			if (uiNiagara == null)
			{
				return;
			}
			uiNiagara.SetUIActive(active);
		}

		// Token: 0x06038AEA RID: 232170 RVA: 0x00E5A965 File Offset: 0x00E58B65
		private void PlayEnterEffectStart()
		{
			this.SetPlotActive(true);
			this.SetPlotLight(true);
			this.PlayEnterTickCallback(0f);
			this.SetPlotNewUnlock(false);
		}

		// Token: 0x06038AEB RID: 232171 RVA: 0x00E5A988 File Offset: 0x00E58B88
		private void PlayEnterTickCallback(float addDeltaTime)
		{
			float curveValue = this.GetCurveValue(addDeltaTime, this.EnterConfig);
			this.SetPlotLightAlpha(curveValue);
		}

		// Token: 0x06038AEC RID: 232172 RVA: 0x00E5A9AA File Offset: 0x00E58BAA
		private void PlayLoopEffectStart()
		{
			this.SetPlotActive(true);
			this.SetPlotLight(true);
			this.PlayLoopTickCallback(0f);
			this.SetPlotNewUnlock(false);
		}

		// Token: 0x06038AED RID: 232173 RVA: 0x00E5A9CC File Offset: 0x00E58BCC
		private void PlayLoopTickCallback(float addDeltaTime)
		{
			float curveValue = this.GetCurveValue(addDeltaTime, this.LoopConfig);
			this.SetPlotLightAlpha(curveValue);
		}

		// Token: 0x06038AEE RID: 232174 RVA: 0x00E5A9EE File Offset: 0x00E58BEE
		private void PlayNewUnlockEffectStart()
		{
			this.SetPlotActive(true);
			this.SetPlotLight(false);
			this.SetPlotLightAlpha(0f);
			this.SetPlotNewUnlock(true);
		}

		// Token: 0x06038AEF RID: 232175 RVA: 0x00E5AA10 File Offset: 0x00E58C10
		private float GetCurveTime(UCurveFloat curve)
		{
			int num = (curve != null) ? curve.FloatCurve.Keys.Num() : 0;
			return ((num > 0) ? curve.FloatCurve.Keys.Get(num - 1).Time : 1f) * 1000f;
		}

		// Token: 0x06038AF0 RID: 232176 RVA: 0x00E5AA5D File Offset: 0x00E58C5D
		private float GetCurveValue(float time, BP_MoraleEffectConfig_C config)
		{
			UCurveFloat ucurveFloat = (config != null) ? config.格子入场曲线 : null;
			if (ucurveFloat == null)
			{
				return 0f;
			}
			return ucurveFloat.GetFloatValue(time / 1000f);
		}

		// Token: 0x06038AF1 RID: 232177 RVA: 0x00E5AA81 File Offset: 0x00E58C81
		public void OnTick(float delta)
		{
			MoraleTickPromise enterTickPromise = this.EnterTickPromise;
			if (enterTickPromise != null)
			{
				enterTickPromise.Tick(delta);
			}
			MoraleTickPromise newUnlockTickPromise = this.NewUnlockTickPromise;
			if (newUnlockTickPromise != null)
			{
				newUnlockTickPromise.Tick(delta);
			}
			MoraleTickPromise loopTickPromise = this.LoopTickPromise;
			if (loopTickPromise == null)
			{
				return;
			}
			loopTickPromise.Tick(delta);
		}

		// Token: 0x06038AF2 RID: 232178 RVA: 0x00E5AAB8 File Offset: 0x00E58CB8
		public UniTask PlayEnterEffect()
		{
			MoraleAreaPlotItem.<PlayEnterEffect>d__24 <PlayEnterEffect>d__;
			<PlayEnterEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayEnterEffect>d__.<>4__this = this;
			<PlayEnterEffect>d__.<>1__state = -1;
			<PlayEnterEffect>d__.<>t__builder.Start<MoraleAreaPlotItem.<PlayEnterEffect>d__24>(ref <PlayEnterEffect>d__);
			return <PlayEnterEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038AF3 RID: 232179 RVA: 0x00E5AAFC File Offset: 0x00E58CFC
		public UniTask PlayNewUnlockEffect()
		{
			MoraleAreaPlotItem.<PlayNewUnlockEffect>d__25 <PlayNewUnlockEffect>d__;
			<PlayNewUnlockEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayNewUnlockEffect>d__.<>4__this = this;
			<PlayNewUnlockEffect>d__.<>1__state = -1;
			<PlayNewUnlockEffect>d__.<>t__builder.Start<MoraleAreaPlotItem.<PlayNewUnlockEffect>d__25>(ref <PlayNewUnlockEffect>d__);
			return <PlayNewUnlockEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038AF4 RID: 232180 RVA: 0x00E5AB40 File Offset: 0x00E58D40
		public UniTask PlayLoopEffect()
		{
			MoraleAreaPlotItem.<PlayLoopEffect>d__26 <PlayLoopEffect>d__;
			<PlayLoopEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayLoopEffect>d__.<>4__this = this;
			<PlayLoopEffect>d__.<>1__state = -1;
			<PlayLoopEffect>d__.<>t__builder.Start<MoraleAreaPlotItem.<PlayLoopEffect>d__26>(ref <PlayLoopEffect>d__);
			return <PlayLoopEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06038AF5 RID: 232181 RVA: 0x00E5AB83 File Offset: 0x00E58D83
		protected override void OnBeforeDestroy()
		{
			MoraleTickPromise enterTickPromise = this.EnterTickPromise;
			if (enterTickPromise != null)
			{
				enterTickPromise.Destroy();
			}
			MoraleTickPromise newUnlockTickPromise = this.NewUnlockTickPromise;
			if (newUnlockTickPromise != null)
			{
				newUnlockTickPromise.Destroy();
			}
			MoraleTickPromise loopTickPromise = this.LoopTickPromise;
			if (loopTickPromise == null)
			{
				return;
			}
			loopTickPromise.Destroy();
		}

		// Token: 0x0402050A RID: 132362
		[Nullable(1)]
		public MoraleAreaPlotData PlotData;

		// Token: 0x0402050B RID: 132363
		[Nullable(1)]
		public BP_MoraleEffectConfig_C EnterConfig;

		// Token: 0x0402050C RID: 132364
		[Nullable(1)]
		public BP_MoraleEffectConfig_C LoopConfig;

		// Token: 0x0402050D RID: 132365
		public MoraleTickPromise EnterTickPromise;

		// Token: 0x0402050E RID: 132366
		public MoraleTickPromise NewUnlockTickPromise;

		// Token: 0x0402050F RID: 132367
		public MoraleTickPromise LoopTickPromise;

		// Token: 0x0200B77C RID: 46972
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04038C0B RID: 232459
			ItemPlotRoot,
			// Token: 0x04038C0C RID: 232460
			SpriteIcon,
			// Token: 0x04038C0D RID: 232461
			ItemLight,
			// Token: 0x04038C0E RID: 232462
			UiNiagaraNewUnlock
		}
	}
}
