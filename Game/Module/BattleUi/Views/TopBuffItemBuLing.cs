using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200611D RID: 24861
	public class TopBuffItemBuLing : TopBuffItem
	{
		// Token: 0x0603ECD2 RID: 257234 RVA: 0x01015080 File Offset: 0x01013280
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
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
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ECD3 RID: 257235 RVA: 0x010151D4 File Offset: 0x010133D4
		protected override void OnStart()
		{
			base.InitTweenAnim(1);
			base.InitTweenAnim(2);
			base.InitTweenAnim(3);
			base.InitTweenAnim(4);
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x0603ECD4 RID: 257236 RVA: 0x01015228 File Offset: 0x01013428
		public void Refresh(int id, int state, int usedType, bool playAnim = false)
		{
			if (this.CurId != id)
			{
				if (id == 0)
				{
					if (this.CurState == 1)
					{
						if (usedType == 1)
						{
							this.PlayTweenAnimOnly(4);
						}
						else if (usedType == 2)
						{
							this.PlayTweenAnimOnly(3);
						}
					}
					else
					{
						this.PlayTweenAnimOnly(5);
					}
				}
				else
				{
					if (this.CurId == 0)
					{
						this.PlayTweenAnimOnly(1);
					}
					base.GetItem(8).SetUIActive(id == 1);
					base.GetItem(7).SetUIActive(id == 2);
				}
				this.CurId = id;
			}
			if (this.CurState != state)
			{
				if (this.CurState != 1 && state == 1)
				{
					base.StopTweenAnim(6);
					base.PlayTweenAnim(2);
				}
				else if (this.CurState == 1 && state != 1)
				{
					base.StopTweenAnim(2);
					base.PlayTweenAnim(6);
				}
				this.CurState = state;
			}
			if (id == 0)
			{
				if (this.HideTime == 0.0)
				{
					if (playAnim)
					{
						this.HideTime = Singleton<Time>.Instance.Now + 500.0;
						return;
					}
					base.SetVisible(1, false);
				}
				return;
			}
			this.HideTime = 0.0;
			base.SetVisible(1, true);
			int num = (id - 1) * 2 + ((state == 1) ? 1 : 0);
			if (this.IconIndex == num)
			{
				return;
			}
			this.IconIndex = num;
			string resourceId;
			if (!TopBuffItemBuLing.IconList.TryGetValue(num, out resourceId))
			{
				return;
			}
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetIcon(resourcePath);
		}

		// Token: 0x0603ECD5 RID: 257237 RVA: 0x0101537D File Offset: 0x0101357D
		[NullableContext(2)]
		public void SetIcon(string iconPath)
		{
			base.GetTexture(0).SetUIActive(false);
			if (string.IsNullOrEmpty(iconPath))
			{
				return;
			}
			this.LoadIconId = Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(iconPath, delegate([Nullable(2)] UTexture skillIconTexture, string _)
			{
				this.LoadIconId = -1;
				if (skillIconTexture == null)
				{
					return;
				}
				UUITexture texture = base.GetTexture(0);
				if (texture == null)
				{
					return;
				}
				texture.SetUIActive(true);
				texture.SetTexture(skillIconTexture);
			}, 103, "js_undefined");
		}

		// Token: 0x0603ECD6 RID: 257238 RVA: 0x010153B9 File Offset: 0x010135B9
		protected override void OnBeforeDestroyImplement()
		{
			base.OnBeforeDestroyImplement();
			if (this.LoadIconId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.LoadIconId);
				this.LoadIconId = -1;
			}
		}

		// Token: 0x0603ECD7 RID: 257239 RVA: 0x010153E1 File Offset: 0x010135E1
		protected void PlayTweenAnimOnly(int componentType)
		{
			if (this.LastAni >= 0)
			{
				base.StopTweenAnim(this.LastAni);
			}
			this.LastAni = componentType;
			base.PlayTweenAnim(componentType);
		}

		// Token: 0x0603ECD8 RID: 257240 RVA: 0x01015406 File Offset: 0x01013606
		public void TickHiding(float delta)
		{
			if (this.HideTime <= 0.0)
			{
				return;
			}
			if (this.HideTime > Singleton<Time>.Instance.Now)
			{
				return;
			}
			base.SetVisible(1, false);
			this.HideTime = 0.0;
		}

		// Token: 0x04023390 RID: 144272
		private const double HIDE_ANIM_TIME = 500.0;

		// Token: 0x04023391 RID: 144273
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly string[] IconList = new string[]
		{
			"T_BulingBuffBlueNor",
			"T_BulingBuffBlueA",
			"T_BulingBuffOrangeNor",
			"T_BulingBuffOrangeA"
		};

		// Token: 0x04023392 RID: 144274
		private int IconIndex;

		// Token: 0x04023393 RID: 144275
		private int CurId;

		// Token: 0x04023394 RID: 144276
		private int CurState;

		// Token: 0x04023395 RID: 144277
		private int LastAni = -1;

		// Token: 0x04023396 RID: 144278
		private int LoadIconId;

		// Token: 0x04023397 RID: 144279
		private double HideTime;

		// Token: 0x0200C2A6 RID: 49830
		private enum EChildType
		{
			// Token: 0x0403C02B RID: 245803
			IconTexture,
			// Token: 0x0403C02C RID: 245804
			AniIn,
			// Token: 0x0403C02D RID: 245805
			AniUsable,
			// Token: 0x0403C02E RID: 245806
			AniUsedRight,
			// Token: 0x0403C02F RID: 245807
			AniUsedLeft,
			// Token: 0x0403C030 RID: 245808
			AniPunish,
			// Token: 0x0403C031 RID: 245809
			AniUsableOut,
			// Token: 0x0403C032 RID: 245810
			OrangeNode,
			// Token: 0x0403C033 RID: 245811
			BlueNode
		}
	}
}
