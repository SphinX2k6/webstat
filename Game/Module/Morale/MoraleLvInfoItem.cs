using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x02005716 RID: 22294
	public class MoraleLvInfoItem : UiPanelBase
	{
		// Token: 0x06038BF4 RID: 232436 RVA: 0x00E5E79C File Offset: 0x00E5C99C
		[NullableContext(1)]
		public UniTask Init(UUIItem item)
		{
			MoraleLvInfoItem.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<MoraleLvInfoItem.<Init>d__1>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06038BF5 RID: 232437 RVA: 0x00E5E7E8 File Offset: 0x00E5C9E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIArtText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnBtnHelp))
			};
		}

		// Token: 0x06038BF6 RID: 232438 RVA: 0x00E5E894 File Offset: 0x00E5CA94
		protected override UniTask OnBeforeStartAsync()
		{
			MoraleLvInfoItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MoraleLvInfoItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038BF7 RID: 232439 RVA: 0x00E5E8D7 File Offset: 0x00E5CAD7
		private void OnBtnHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(328);
		}

		// Token: 0x06038BF8 RID: 232440 RVA: 0x00E5E8E8 File Offset: 0x00E5CAE8
		public void UpdateData()
		{
			MoraleBattleModel instance = ModelBase<MoraleBattleModel>.Instance;
			int moraleLevel = instance.GetMoraleLevel();
			base.GetArtText(0).SetText(moraleLevel.ToString());
			int moraleCurrentLevelExp = instance.GetMoraleCurrentLevelExp();
			int moraleLevelUpExp = instance.GetMoraleLevelUpExp(null);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(moraleCurrentLevelExp);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(moraleLevelUpExp);
			string newText = defaultInterpolatedStringHandler.ToStringAndClear();
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(newText, true);
			}
			float moraleCurrentExpProgress = instance.GetMoraleCurrentExpProgress();
			UUISprite sprite = base.GetSprite(2);
			if (sprite != null)
			{
				sprite.SetFillAmount(moraleCurrentExpProgress);
			}
			UUIText text2 = base.GetText(4);
			if (text2 == null)
			{
				return;
			}
			text2.ShowTextNew("Morale_title_2");
		}

		// Token: 0x0200B7BA RID: 47034
		private class EChildType
		{
			// Token: 0x04038D4D RID: 232781
			public const int ArtTextMoraleLv = 0;

			// Token: 0x04038D4E RID: 232782
			public const int TxtMoraleLvExpProgress = 1;

			// Token: 0x04038D4F RID: 232783
			public const int SpriteMoraleLvExpProgress = 2;

			// Token: 0x04038D50 RID: 232784
			public const int BtnHelp = 3;

			// Token: 0x04038D51 RID: 232785
			public const int TxtTitle = 4;
		}
	}
}
