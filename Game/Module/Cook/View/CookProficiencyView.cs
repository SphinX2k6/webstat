using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E20 RID: 24096
	[NullableContext(2)]
	[Nullable(0)]
	public class CookProficiencyView : UiPanelBase
	{
		// Token: 0x0603C9FE RID: 248318 RVA: 0x00F653A8 File Offset: 0x00F635A8
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
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(delegate()
			{
				this.OnChangeRoleClick();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C9FF RID: 248319 RVA: 0x00F65490 File Offset: 0x00F63690
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(base.GetButton(2).GetRootComponent());
		}

		// Token: 0x0603CA00 RID: 248320 RVA: 0x00F654A9 File Offset: 0x00F636A9
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x0603CA01 RID: 248321 RVA: 0x00F654B6 File Offset: 0x00F636B6
		private void OnChangeRoleClick()
		{
			Action changeClickCall = this.ChangeClickCall;
			if (changeClickCall == null)
			{
				return;
			}
			changeClickCall();
		}

		// Token: 0x0603CA02 RID: 248322 RVA: 0x00F654C8 File Offset: 0x00F636C8
		[NullableContext(1)]
		public void BindChangeRoleClick(Action func)
		{
			this.ChangeClickCall = func;
		}

		// Token: 0x0603CA03 RID: 248323 RVA: 0x00F654D4 File Offset: 0x00F636D4
		public void SetExpNum(int cookCount, int single, int sum, int times)
		{
			int num = single * sum;
			int num2 = cookCount * single;
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

		// Token: 0x0603CA04 RID: 248324 RVA: 0x00F655DC File Offset: 0x00F637DC
		public void SetRoleTexture(int roleId, int itemId)
		{
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
			base.SetRoleIcon(roleDataById.GetRoleConfig().RoleHeadIconLarge, base.GetTexture(1), roleId, null, null);
			if (ControllerBase<CookController>.Instance.CheckIsBuffEx(roleId, itemId))
			{
				if (this.SequencePlayer.GetCurrentSequence() == null)
				{
					this.SequencePlayer.PlayLevelSequenceByName("Show", false, null, false);
					return;
				}
				this.SequencePlayer.ReplaySequenceByKey("Show");
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

		// Token: 0x0603CA05 RID: 248325 RVA: 0x00F65678 File Offset: 0x00F63878
		public void SetTypeContent(string content = null)
		{
			UUIText text = base.GetText(3);
			if (content != null)
			{
				text.SetUIActive(true);
				text.SetText(content, true);
				return;
			}
			text.SetUIActive(false);
		}

		// Token: 0x040220FF RID: 139519
		private Action ChangeClickCall;

		// Token: 0x04022100 RID: 139520
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x0200BE54 RID: 48724
		[NullableContext(0)]
		private enum EProficiencyViewComponents
		{
			// Token: 0x0403A992 RID: 240018
			TxtAddNum,
			// Token: 0x0403A993 RID: 240019
			TexRole,
			// Token: 0x0403A994 RID: 240020
			BtnChange,
			// Token: 0x0403A995 RID: 240021
			TxtType
		}
	}
}
