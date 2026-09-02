using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Field
{
	// Token: 0x020055C4 RID: 21956
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaFieldArea : UiPanelBase
	{
		// Token: 0x06037EC9 RID: 229065 RVA: 0x00E2B158 File Offset: 0x00E29358
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUINiagara)),
				new ValueTuple<int, Type>(3, typeof(UUINiagara)),
				new ValueTuple<int, Type>(4, typeof(UUITexture)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUITexture))
			};
		}

		// Token: 0x06037ECA RID: 229066 RVA: 0x00E2B220 File Offset: 0x00E29420
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaFieldArea.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaFieldArea.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037ECB RID: 229067 RVA: 0x00E2B263 File Offset: 0x00E29463
		private void FieldPointerEnter(PhantomArenaFieldData fieldData, UUIItem attachItem)
		{
			this.ViewProxy.FieldPointerEnter(fieldData, attachItem, false);
		}

		// Token: 0x06037ECC RID: 229068 RVA: 0x00E2B273 File Offset: 0x00E29473
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
		}

		// Token: 0x06037ECD RID: 229069 RVA: 0x00E2B29D File Offset: 0x00E2949D
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037ECE RID: 229070 RVA: 0x00E2B2AA File Offset: 0x00E294AA
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.FieldItem.SetFieldItemActive(false);
			}
		}

		// Token: 0x06037ECF RID: 229071 RVA: 0x00E2B2C8 File Offset: 0x00E294C8
		private void RefreshNiagaraState()
		{
			if (this.FieldData.CardData != null)
			{
				UUINiagara uiNiagara = base.GetUiNiagara(2);
				UUINiagara uiNiagara2 = base.GetUiNiagara(3);
				if (!StringUtils.IsBlank(this.FieldData.FieldLightColor))
				{
					uiNiagara.SetColor(FColor.FromHex(this.FieldData.FieldLightColor));
				}
				if (!StringUtils.IsBlank(this.FieldData.FieldReleaseColor))
				{
					uiNiagara2.SetColor(FColor.FromHex(this.FieldData.FieldReleaseColor));
				}
			}
		}

		// Token: 0x06037ED0 RID: 229072 RVA: 0x00E2B344 File Offset: 0x00E29544
		private UniTask RefreshTexState()
		{
			PhantomArenaFieldArea.<RefreshTexState>d__12 <RefreshTexState>d__;
			<RefreshTexState>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTexState>d__.<>4__this = this;
			<RefreshTexState>d__.<>1__state = -1;
			<RefreshTexState>d__.<>t__builder.Start<PhantomArenaFieldArea.<RefreshTexState>d__12>(ref <RefreshTexState>d__);
			return <RefreshTexState>d__.<>t__builder.Task;
		}

		// Token: 0x06037ED1 RID: 229073 RVA: 0x00E2B388 File Offset: 0x00E29588
		private UniTask PlayReleaseSequence()
		{
			PhantomArenaFieldArea.<PlayReleaseSequence>d__13 <PlayReleaseSequence>d__;
			<PlayReleaseSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayReleaseSequence>d__.<>4__this = this;
			<PlayReleaseSequence>d__.<>1__state = -1;
			<PlayReleaseSequence>d__.<>t__builder.Start<PhantomArenaFieldArea.<PlayReleaseSequence>d__13>(ref <PlayReleaseSequence>d__);
			return <PlayReleaseSequence>d__.<>t__builder.Task;
		}

		// Token: 0x06037ED2 RID: 229074 RVA: 0x00E2B3CC File Offset: 0x00E295CC
		public UniTask Refresh(PhantomArenaFieldData filedData)
		{
			PhantomArenaFieldArea.<Refresh>d__14 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.filedData = filedData;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<PhantomArenaFieldArea.<Refresh>d__14>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06037ED3 RID: 229075 RVA: 0x00E2B418 File Offset: 0x00E29618
		public UniTask RefreshSelf()
		{
			PhantomArenaFieldArea.<RefreshSelf>d__15 <RefreshSelf>d__;
			<RefreshSelf>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshSelf>d__.<>4__this = this;
			<RefreshSelf>d__.<>1__state = -1;
			<RefreshSelf>d__.<>t__builder.Start<PhantomArenaFieldArea.<RefreshSelf>d__15>(ref <RefreshSelf>d__);
			return <RefreshSelf>d__.<>t__builder.Task;
		}

		// Token: 0x06037ED4 RID: 229076 RVA: 0x00E2B45C File Offset: 0x00E2965C
		public UniTask TriggerSkill()
		{
			PhantomArenaFieldArea.<TriggerSkill>d__16 <TriggerSkill>d__;
			<TriggerSkill>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<TriggerSkill>d__.<>4__this = this;
			<TriggerSkill>d__.<>1__state = -1;
			<TriggerSkill>d__.<>t__builder.Start<PhantomArenaFieldArea.<TriggerSkill>d__16>(ref <TriggerSkill>d__);
			return <TriggerSkill>d__.<>t__builder.Task;
		}

		// Token: 0x06037ED5 RID: 229077 RVA: 0x00E2B49F File Offset: 0x00E2969F
		public void ResetSkillTrigger()
		{
			this.FieldItem.ResetSkill();
		}

		// Token: 0x06037ED6 RID: 229078 RVA: 0x00E2B4AC File Offset: 0x00E296AC
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x06037ED7 RID: 229079 RVA: 0x00E2B4B8 File Offset: 0x00E296B8
		public void SwitchFieldState(bool active)
		{
			if (this.FieldData.CardData != null && active)
			{
				this.FieldItem.SetFieldItemActive(true);
				this.Sequence.PlaySequence("Start", false, null);
				return;
			}
			this.Sequence.PlaySequence("Close", false, null);
		}

		// Token: 0x0401FFE3 RID: 131043
		public PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFE4 RID: 131044
		protected PhantomArenaFieldItem FieldItem;

		// Token: 0x0401FFE5 RID: 131045
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFE6 RID: 131046
		protected PhantomArenaFieldData FieldData;

		// Token: 0x0200B5A6 RID: 46502
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038356 RID: 230230
			public const int FieldItem = 0;

			// Token: 0x04038357 RID: 230231
			public const int SkillName = 1;

			// Token: 0x04038358 RID: 230232
			public const int NiagaraLight = 2;

			// Token: 0x04038359 RID: 230233
			public const int NiagaraRelease = 3;

			// Token: 0x0403835A RID: 230234
			public const int TextRelease = 4;

			// Token: 0x0403835B RID: 230235
			public const int TexBg = 5;

			// Token: 0x0403835C RID: 230236
			public const int TexIcon = 6;

			// Token: 0x0403835D RID: 230237
			public const int TexSmoke = 7;
		}
	}
}
