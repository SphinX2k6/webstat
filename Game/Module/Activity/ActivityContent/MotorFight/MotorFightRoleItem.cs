using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066DD RID: 26333
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorFightRoleItem : GridProxyAbstract<MotorFightRoleData>
	{
		// Token: 0x06041BEF RID: 269295 RVA: 0x010DCAC4 File Offset: 0x010DACC4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041BF0 RID: 269296 RVA: 0x010DCC98 File Offset: 0x010DAE98
		public override void Refresh(MotorFightRoleData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(!data.IsUnLock);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(!data.IsUnLock);
			}
			UUITexture texture = base.GetTexture(7);
			if (texture != null)
			{
				texture.SetUIActive(!data.IsUnLock);
			}
			UUIItem item3 = base.GetItem(3);
			if (item3 != null)
			{
				item3.SetUIActive(data.IsUnLock);
			}
			UUIItem item4 = base.GetItem(4);
			if (item4 != null)
			{
				item4.SetUIActive(data.IsUnLock);
			}
			string hexStr = data.IsUnLock ? "ffffffff" : "2e403c7f";
			UUITexture texture2 = base.GetTexture(5);
			if (texture2 != null)
			{
				texture2.SetColor(FColor.FromHex(hexStr));
			}
			base.SetTextureByPath(data.RoleTexture, base.GetTexture(5), null, null);
			UUISprite sprite = base.GetSprite(6);
			if (sprite != null)
			{
				sprite.SetUIActive(this.IsSelected(data.Id));
			}
			bool uiactive = false;
			using (List<int>.Enumerator enumerator = this.RecommendRoleIds.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current == data.Id)
					{
						uiactive = true;
						break;
					}
				}
			}
			UUISprite sprite2 = base.GetSprite(8);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(uiactive);
			}
			this.SetSpriteByPath(this.numberList[gridIndex], base.GetSprite(9), false, null, null);
			UUIItem item5 = base.GetItem(10);
			if (item5 == null)
			{
				return;
			}
			item5.SetUIActive(data.HasRedDot);
		}

		// Token: 0x06041BF1 RID: 269297 RVA: 0x010DCE38 File Offset: 0x010DB038
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x06041BF2 RID: 269298 RVA: 0x010DCE60 File Offset: 0x010DB060
		public override void OnSelected(bool fireEvent)
		{
			this.Data.ReadRedDot();
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			string hexStr = this.Data.IsUnLock ? "ffffffff" : "2e403cff";
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetColor(FColor.FromHex(hexStr));
			}
			this.SetToggleState(true);
		}

		// Token: 0x06041BF3 RID: 269299 RVA: 0x010DCEC8 File Offset: 0x010DB0C8
		public override void OnDeselected(bool fireEvent)
		{
			string hexStr = this.Data.IsUnLock ? "ffffffff" : "2e403c7f";
			UUITexture texture = base.GetTexture(5);
			if (texture != null)
			{
				texture.SetColor(FColor.FromHex(hexStr));
			}
			this.SetToggleState(false);
		}

		// Token: 0x06041BF4 RID: 269300 RVA: 0x010DCF0E File Offset: 0x010DB10E
		private void OnToggleClick(EToggleState _)
		{
			this.OnToggleClickCallback(this.Data);
		}

		// Token: 0x06041BF5 RID: 269301 RVA: 0x010DCF21 File Offset: 0x010DB121
		public override object GetKey(MotorFightRoleData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x04024AEB RID: 150251
		public readonly List<string> numberList = new List<string>
		{
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/MotorcycleBattle/SelectRole/SP_SelectRoleNum01.SP_SelectRoleNum01",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/MotorcycleBattle/SelectRole/SP_SelectRoleNum02.SP_SelectRoleNum02",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/MotorcycleBattle/SelectRole/SP_SelectRoleNum03.SP_SelectRoleNum03",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity31/MotorcycleBattle/SelectRole/SP_SelectRoleNum04.SP_SelectRoleNum04"
		};

		// Token: 0x04024AEC RID: 150252
		private MotorFightRoleData Data;

		// Token: 0x04024AED RID: 150253
		public List<int> RecommendRoleIds = new List<int>();

		// Token: 0x04024AEE RID: 150254
		public Action<MotorFightRoleData> OnToggleClickCallback = delegate(MotorFightRoleData data)
		{
		};

		// Token: 0x04024AEF RID: 150255
		public Func<int, bool> IsSelected = (int roleId) => false;

		// Token: 0x0200C70C RID: 50956
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D48A RID: 251018
			public const int ToggleRoot = 0;

			// Token: 0x0403D48B RID: 251019
			public const int ItemBgLockPanel = 1;

			// Token: 0x0403D48C RID: 251020
			public const int ItemLockPanel = 2;

			// Token: 0x0403D48D RID: 251021
			public const int ItemBgUnlockPanel = 3;

			// Token: 0x0403D48E RID: 251022
			public const int ItemUnlockPanel = 4;

			// Token: 0x0403D48F RID: 251023
			public const int TextureRole = 5;

			// Token: 0x0403D490 RID: 251024
			public const int SpriteSelected = 6;

			// Token: 0x0403D491 RID: 251025
			public const int TextureLock = 7;

			// Token: 0x0403D492 RID: 251026
			public const int SpriteRecommend = 8;

			// Token: 0x0403D493 RID: 251027
			public const int SpriteNumber = 9;

			// Token: 0x0403D494 RID: 251028
			public const int ItemRedDot = 10;
		}
	}
}
