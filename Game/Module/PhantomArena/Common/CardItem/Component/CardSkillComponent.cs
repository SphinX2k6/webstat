using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005555 RID: 21845
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardSkillComponent : CardComponentBase<ICardSkillComponentData>
	{
		// Token: 0x06037AB5 RID: 228021 RVA: 0x00E1E918 File Offset: 0x00E1CB18
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnSkillBtnClick))
			};
		}

		// Token: 0x06037AB6 RID: 228022 RVA: 0x00E1E9AB File Offset: 0x00E1CBAB
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEndEvent));
		}

		// Token: 0x06037AB7 RID: 228023 RVA: 0x00E1E9D5 File Offset: 0x00E1CBD5
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037AB8 RID: 228024 RVA: 0x00E1E9E2 File Offset: 0x00E1CBE2
		private void OnSkillBtnClick()
		{
			this.SkillBtnClick();
		}

		// Token: 0x06037AB9 RID: 228025 RVA: 0x00E1E9F0 File Offset: 0x00E1CBF0
		private void OnSequenceEndEvent(string sequenceName)
		{
			if (sequenceName == "NorToUse")
			{
				base.GetItem(0).SetUIActive(false);
				return;
			}
			if (sequenceName == "UseToNor")
			{
				base.GetButton(3).RootUIComp.Get().SetUIActive(false);
				return;
			}
			if (sequenceName == "UseToCd")
			{
				base.GetButton(3).RootUIComp.Get().SetUIActive(false);
				return;
			}
			if (sequenceName == "CdToNor")
			{
				base.GetSprite(2).SetUIActive(false);
			}
		}

		// Token: 0x06037ABA RID: 228026 RVA: 0x00E1EA84 File Offset: 0x00E1CC84
		private void SwitchUseToNor()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("UseToNor", false, null);
			base.GetItem(0).SetUIActive(true);
		}

		// Token: 0x06037ABB RID: 228027 RVA: 0x00E1EAC8 File Offset: 0x00E1CCC8
		private void SwitchNorToUse()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("NorToUse", false, null);
			base.GetItem(0).SetUIActive(true);
			base.GetButton(3).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06037ABC RID: 228028 RVA: 0x00E1EB24 File Offset: 0x00E1CD24
		private void SwitchCdToNor()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("CdToNor", false, null);
			base.GetSprite(1).SetUIActive(true);
		}

		// Token: 0x06037ABD RID: 228029 RVA: 0x00E1EB68 File Offset: 0x00E1CD68
		private void SwitchUseToCd()
		{
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("UseToCd", false, null);
			base.GetItem(0).SetUIActive(true);
			base.GetButton(3).RootUIComp.Get().SetUIActive(false);
			base.GetSprite(2).SetUIActive(true);
		}

		// Token: 0x06037ABE RID: 228030 RVA: 0x00E1EBD0 File Offset: 0x00E1CDD0
		public override void Refresh(ICardSkillComponentData data)
		{
			if (!data.InFight)
			{
				this.SetActive(false);
				this.Data = data;
				return;
			}
			this.SetActive(true);
			if (data.InSelect && data.SkillCd <= 0)
			{
				this.TriggerCanUseState();
			}
			else
			{
				this.TriggerNormalState(data);
			}
			this.Data = data;
		}

		// Token: 0x06037ABF RID: 228031 RVA: 0x00E1EC22 File Offset: 0x00E1CE22
		public void TriggerCanUseState()
		{
			this.SwitchNorToUse();
		}

		// Token: 0x06037AC0 RID: 228032 RVA: 0x00E1EC2C File Offset: 0x00E1CE2C
		public void TriggerNormalState(ICardSkillComponentData data)
		{
			ICardSkillComponentData data2 = this.Data;
			bool flag;
			if (data2 == null)
			{
				flag = false;
			}
			else
			{
				int skillCd = data2.SkillCd;
				flag = true;
			}
			bool flag2 = flag && this.Data.SkillCd > 0;
			if (data.SkillCd > 0)
			{
				if (!flag2)
				{
					this.SwitchUseToCd();
					return;
				}
			}
			else
			{
				if (flag2)
				{
					this.SwitchCdToNor();
					return;
				}
				if (!data.InSelect)
				{
					ICardSkillComponentData data3 = this.Data;
					if (data3 != null && data3.InSelect)
					{
						this.SwitchUseToNor();
					}
				}
			}
		}

		// Token: 0x0401FE68 RID: 130664
		public Action SkillBtnClick;

		// Token: 0x0401FE69 RID: 130665
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FE6A RID: 130666
		protected ICardSkillComponentData Data;

		// Token: 0x0200B4DE RID: 46302
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04037FC8 RID: 229320
			public const int NormalItem = 0;

			// Token: 0x04037FC9 RID: 229321
			public const int NormalIcon = 1;

			// Token: 0x04037FCA RID: 229322
			public const int CountDownIcon = 2;

			// Token: 0x04037FCB RID: 229323
			public const int SkillBtn = 3;
		}
	}
}
