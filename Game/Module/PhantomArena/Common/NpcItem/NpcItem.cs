using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.NpcItem
{
	// Token: 0x02005525 RID: 21797
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NpcItem : GridProxyAbstract<GymChallengeData>
	{
		// Token: 0x060379AC RID: 227756 RVA: 0x00E1BEF8 File Offset: 0x00E1A0F8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
			};
		}

		// Token: 0x060379AD RID: 227757 RVA: 0x00E1C010 File Offset: 0x00E1A210
		protected override void OnStart()
		{
			base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnUndeterminedClicked));
		}

		// Token: 0x060379AE RID: 227758 RVA: 0x00E1C030 File Offset: 0x00E1A230
		[NullableContext(1)]
		public override void Refresh(GymChallengeData data, bool isSelected, int gridIndex)
		{
			this.ChallengeData = data;
			EChallengeState challengeStateById = ModelBase<PhantomArenaModel>.Instance.GetChallengeStateById(data.Id);
			bool flag = challengeStateById == EChallengeState.Lock;
			bool uiactive = challengeStateById == EChallengeState.Finish;
			PhantomBattleChallenge phantomBattleChallengeConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallengeConfig(data.Id);
			this.SetSelected(isSelected);
			base.GetTexture(5).SetUIActive(data.IsLast);
			base.GetTexture(2).SetUIActive(data.IsLast);
			base.GetTexture(1).SetUIActive(!data.IsLast);
			base.GetItem(7).SetUIActive(flag && data.IsLast);
			base.GetItem(8).SetUIActive(!data.IsLast);
			base.GetItem(9).SetUIActive(uiactive);
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(4), phantomBattleChallengeConfig.NpcName, Array.Empty<object>());
			base.TrySetTextureByPath(phantomBattleChallengeConfig.NpcIcon, base.GetTexture(3), null, null);
		}

		// Token: 0x060379AF RID: 227759 RVA: 0x00E1C124 File Offset: 0x00E1A324
		public void SetSelected(bool isSelected)
		{
			PhantomArenaModel instance = ModelBase<PhantomArenaModel>.Instance;
			GymChallengeData challengeData = this.ChallengeData;
			bool flag = instance.IsChallengeLock((challengeData != null) ? challengeData.Id : 0);
			EToggleState etoggleState = (!flag && isSelected) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			EToggleState state = flag ? EToggleState.ETT_UnDetermined : etoggleState;
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x060379B0 RID: 227760 RVA: 0x00E1C172 File Offset: 0x00E1A372
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true);
		}

		// Token: 0x060379B1 RID: 227761 RVA: 0x00E1C17B File Offset: 0x00E1A37B
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false);
		}

		// Token: 0x060379B2 RID: 227762 RVA: 0x00E1C184 File Offset: 0x00E1A384
		private void OnUndeterminedClicked()
		{
			if (this.CallbackOnClick != null && this.ChallengeData != null)
			{
				EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
				this.CallbackOnClick(this.ChallengeData, base.GridIndex, toggleState);
			}
		}

		// Token: 0x060379B3 RID: 227763 RVA: 0x00E1C1C8 File Offset: 0x00E1A3C8
		private void OnClickToggle(EToggleState toggleState)
		{
			if (this.CallbackOnClick != null && this.ChallengeData != null)
			{
				EToggleState toggleState2 = base.GetExtendToggle(0).GetToggleState();
				this.CallbackOnClick(this.ChallengeData, base.GridIndex, toggleState2);
			}
		}

		// Token: 0x0401FE10 RID: 130576
		[Nullable(2)]
		public GymChallengeData ChallengeData;

		// Token: 0x0401FE11 RID: 130577
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<GymChallengeData, int, EToggleState> CallbackOnClick;

		// Token: 0x0200B4BF RID: 46271
		private static class EComponents
		{
			// Token: 0x04037F54 RID: 229204
			public const int ToggleNpc = 0;

			// Token: 0x04037F55 RID: 229205
			public const int TextureBgBlue = 1;

			// Token: 0x04037F56 RID: 229206
			public const int TextureBgRed = 2;

			// Token: 0x04037F57 RID: 229207
			public const int TextureMain = 3;

			// Token: 0x04037F58 RID: 229208
			public const int TextName = 4;

			// Token: 0x04037F59 RID: 229209
			public const int TextureTitle = 5;

			// Token: 0x04037F5A RID: 229210
			public const int TextureMask = 6;

			// Token: 0x04037F5B RID: 229211
			public const int PanelLock = 7;

			// Token: 0x04037F5C RID: 229212
			public const int PanelLine = 8;

			// Token: 0x04037F5D RID: 229213
			public const int PanelFinish = 9;
		}
	}
}
