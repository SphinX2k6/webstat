using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E0 RID: 26336
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightTalentNodeItem : UiPanelBase
	{
		// Token: 0x06041C08 RID: 269320 RVA: 0x010DD53C File Offset: 0x010DB73C
		public MotorFightTalentNodeItem(UUIItem parent, MotorFightTalentData data, UUIItem gridPanelItem)
		{
			this.Data = data2;
			this.PreItem = parent;
			this.GridPanelItem = gridPanelItem;
		}

		// Token: 0x06041C09 RID: 269321 RVA: 0x010DD594 File Offset: 0x010DB794
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C0A RID: 269322 RVA: 0x010DD788 File Offset: 0x010DB988
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
		}

		// Token: 0x06041C0B RID: 269323 RVA: 0x010DD798 File Offset: 0x010DB998
		[NullableContext(2)]
		public unsafe void Refresh(MotorFightTalentData data = null)
		{
			this.Data = (data ?? this.Data);
			MotorFightActivityData motorFightActivityData = ControllerBase<MotorFightController>.Instance.GetMotorFightActivityData();
			Span<int> preNode = this.Data.PreNode;
			int i;
			Action<AActor> <>9__0;
			int j;
			for (i = 0; i < preNode.Length; i = j + 1)
			{
				int offset = motorFightActivityData.GetMotorFightTalentData(*preNode[i]).Row - this.Data.Row;
				UUIItem prePosItem = this.GetPrePosItem(offset);
				if (this.LineComponentList.Count <= i || this.LineComponentList[i] == null)
				{
					UniTask<AActor> task = Singleton<LguiUtil>.Instance.LoadPrefabByResourceIdAsync("UiItem_MotorFightTogLine", prePosItem, null, ResourceSystem.EResourceLoadPriority.Default, "js_undefined");
					Action<AActor> continuationFunction;
					if ((continuationFunction = <>9__0) == null)
					{
						continuationFunction = (<>9__0 = delegate(AActor prefab)
						{
							if (prefab == null)
							{
								return;
							}
							MotorFightTalentLine component = new MotorFightTalentLine();
							component.CreateThenShowByActorAsync(prefab, null, false).ContinueWith(delegate()
							{
								component.Refresh(this.Data.IsUnLock);
							});
							if (this.LineComponentList.Count <= i)
							{
								this.LineComponentList.AddRange(Enumerable.Repeat<MotorFightTalentLine>(null, i - this.LineComponentList.Count + 1));
							}
							this.LineComponentList[i] = component;
						});
					}
					task.ContinueWith(continuationFunction);
				}
				else
				{
					this.LineComponentList[i].Refresh(this.Data.IsUnLock);
				}
				j = i;
			}
			bool flag = motorFightActivityData.GetTalentCoinNum() >= this.Data.Cost;
			bool flag2 = motorFightActivityData.IsPreNodeAllUnlock(this.Data);
			UUISprite sprite = base.GetSprite(10);
			this.SetSpriteByPath(this.Data.Icon, sprite, false, null, null);
			UUIItem uuiitem = sprite;
			bool bUseChangeColor = !this.Data.IsUnLock;
			FColor? fcolor = new FColor?(sprite.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			bool flag3 = flag2 && this.Data.IsFinishPreCondition && flag;
			base.GetSprite(7).SetUIActive(!flag3 && !this.Data.IsUnLock);
			base.GetSprite(8).SetUIActive(flag3 && !this.Data.IsUnLock);
			base.GetSprite(11).SetUIActive(flag3 && !this.Data.IsUnLock);
			base.GetSprite(9).SetUIActive(this.Data.IsUnLock);
			if (motorFightActivityData.SelectedTalentNodeId == this.Data.Id)
			{
				this.OnClickCallback(this);
			}
		}

		// Token: 0x06041C0C RID: 269324 RVA: 0x010DD9E4 File Offset: 0x010DBBE4
		public UUIItem GetPrePosItem(int offset)
		{
			if (offset > 0)
			{
				return base.GetItem(3);
			}
			if (offset < 0)
			{
				return base.GetItem(1);
			}
			return base.GetItem(2);
		}

		// Token: 0x06041C0D RID: 269325 RVA: 0x010DDA05 File Offset: 0x010DBC05
		private void OnToggleClick(EToggleState _)
		{
			if (this.OnClickCallback != null)
			{
				this.OnClickCallback(this);
			}
		}

		// Token: 0x06041C0E RID: 269326 RVA: 0x010DDA1B File Offset: 0x010DBC1B
		public void SetToggleState(EToggleState state)
		{
			base.GetExtendToggle(0).SetToggleState(state, false, false, false);
		}

		// Token: 0x04024AF6 RID: 150262
		[Nullable(2)]
		public MotorFightTalentData Data;

		// Token: 0x04024AF7 RID: 150263
		[Nullable(2)]
		public UUIItem PreItem;

		// Token: 0x04024AF8 RID: 150264
		public List<MotorFightTalentLine> LineComponentList = new List<MotorFightTalentLine>();

		// Token: 0x04024AF9 RID: 150265
		[Nullable(2)]
		public UUIItem GridPanelItem;

		// Token: 0x04024AFA RID: 150266
		public Action<MotorFightTalentNodeItem> OnClickCallback = delegate(MotorFightTalentNodeItem data)
		{
		};

		// Token: 0x0200C713 RID: 50963
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D4AA RID: 251050
			public const int Toggle = 0;

			// Token: 0x0403D4AB RID: 251051
			public const int PrePos1 = 1;

			// Token: 0x0403D4AC RID: 251052
			public const int PrePos2 = 2;

			// Token: 0x0403D4AD RID: 251053
			public const int PrePos3 = 3;

			// Token: 0x0403D4AE RID: 251054
			public const int OutPos1 = 4;

			// Token: 0x0403D4AF RID: 251055
			public const int OutPos2 = 5;

			// Token: 0x0403D4B0 RID: 251056
			public const int OutPos3 = 6;

			// Token: 0x0403D4B1 RID: 251057
			public const int SpriteLock = 7;

			// Token: 0x0403D4B2 RID: 251058
			public const int SpriteCanUnlock = 8;

			// Token: 0x0403D4B3 RID: 251059
			public const int SpriteUnlock = 9;

			// Token: 0x0403D4B4 RID: 251060
			public const int SpriteIcon = 10;

			// Token: 0x0403D4B5 RID: 251061
			public const int SpriteUp = 11;
		}
	}
}
