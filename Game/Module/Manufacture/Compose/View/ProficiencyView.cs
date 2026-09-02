using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059C6 RID: 22982
	[NullableContext(2)]
	[Nullable(0)]
	public class ProficiencyView : UiPanelBase
	{
		// Token: 0x0603A37D RID: 238461 RVA: 0x00EBFCE8 File Offset: 0x00EBDEE8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnChangeRoleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A37E RID: 238462 RVA: 0x00EBFDD0 File Offset: 0x00EBDFD0
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetButton(2).RootUIComp);
		}

		// Token: 0x0603A37F RID: 238463 RVA: 0x00EBFDEE File Offset: 0x00EBDFEE
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x0603A380 RID: 238464 RVA: 0x00EBFDFB File Offset: 0x00EBDFFB
		private void OnChangeRoleClick()
		{
			if (this.ChangeClickCall != null)
			{
				this.ChangeClickCall();
			}
		}

		// Token: 0x0603A381 RID: 238465 RVA: 0x00EBFE10 File Offset: 0x00EBE010
		[NullableContext(1)]
		public void BindChangeRoleClick(Action func)
		{
			this.ChangeClickCall = func;
		}

		// Token: 0x0603A382 RID: 238466 RVA: 0x00EBFE1C File Offset: 0x00EBE01C
		public void SetExpNum(int count, int single, int sum, int times)
		{
			int num = single * sum;
			int num2 = count * single;
			int num3 = num - num2;
			string str = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("CumulativeProficiency"), new string[]
			{
				num2.ToString(),
				num.ToString()
			});
			if (num3 > 0)
			{
				int val = Math.Min(num3, single * times);
				string textById = ConfigBase<TextConfig>.Instance.GetTextById("AddProficiency");
				string[] array = new string[1];
				int num4 = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(Math.Min(val, num3));
				array[num4] = defaultInterpolatedStringHandler.ToStringAndClear();
				string newText = StringUtils.Format(textById, array) + " (" + str + ")";
				base.GetText(0).SetText(newText, true);
				return;
			}
			string newText2 = StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("AddProficiency"), new string[]
			{
				""
			}) + " (" + str + ")";
			base.GetText(0).SetText(newText2, true);
		}

		// Token: 0x0603A383 RID: 238467 RVA: 0x00EBFF21 File Offset: 0x00EBE121
		public void SetExpVisible(bool visible)
		{
			base.GetText(0).SetUIActive(visible);
		}

		// Token: 0x0603A384 RID: 238468 RVA: 0x00EBFF30 File Offset: 0x00EBE130
		public void SetRoleTexture(int roleId, int itemId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			base.SetRoleIcon(roleDataById.GetRoleConfig().RoleHeadIconLarge, base.GetTexture(1), roleId, null, null);
			if (Singleton<CommonManager>.Instance.CheckIsBuffEx(roleId, itemId))
			{
				if (this.SequencePlayer.GetCurrentSequence() != null)
				{
					this.SequencePlayer.ReplaySequenceByKey("Show");
					return;
				}
				this.SequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.StopCurrentSequence(false, true);
				return;
			}
		}

		// Token: 0x0603A385 RID: 238469 RVA: 0x00EBFFCC File Offset: 0x00EBE1CC
		public void SetTypeContent(string content = null)
		{
			UUIText text = base.GetText(3);
			if (!string.IsNullOrEmpty(content))
			{
				text.SetUIActive(true);
				text.SetText(content, true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x04021010 RID: 135184
		private Action ChangeClickCall;

		// Token: 0x04021011 RID: 135185
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200B992 RID: 47506
		[NullableContext(0)]
		private class EProficiencyViewComponents
		{
			// Token: 0x0403955B RID: 234843
			public const int TxtAddNum = 0;

			// Token: 0x0403955C RID: 234844
			public const int TexRole = 1;

			// Token: 0x0403955D RID: 234845
			public const int BtnChange = 2;

			// Token: 0x0403955E RID: 234846
			public const int TxtType = 3;
		}
	}
}
