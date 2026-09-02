using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A7 RID: 20903
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeSkillNode : UiPanelBase
	{
		// Token: 0x06035C0D RID: 220173 RVA: 0x00D84404 File Offset: 0x00D82604
		public RoguelikeSkillNode(UUIItem parent, RogueTalentTree data, UUIItem gridPanelItem)
		{
			this.Data = new RogueTalentTree?(data);
			this.PreItem = parent;
			this.GridPanelItem = gridPanelItem;
		}

		// Token: 0x06035C0E RID: 220174 RVA: 0x00D84434 File Offset: 0x00D82634
		protected unsafe override void OnRegisterComponent()
		{
			int num = 13;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
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
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C0F RID: 220175 RVA: 0x00D8460D File Offset: 0x00D8280D
		protected void OnToggleStateChange(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Singleton<EventSystem>.Instance.Emit<RoguelikeSkillNode>(EEventName.RoguelikeSelectSkill, this);
			}
		}

		// Token: 0x06035C10 RID: 220176 RVA: 0x00D84624 File Offset: 0x00D82824
		protected override void OnStart()
		{
			base.GetExtendToggle(11).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			base.GetExtendToggle(11).bLockStateOnSelect = true;
		}

		// Token: 0x06035C11 RID: 220177 RVA: 0x00D84654 File Offset: 0x00D82854
		public void Refresh(RogueTalentTree? data = null)
		{
			this.Data = ((data != null) ? data : this.Data);
			UUIItem uuiitem = this.RootItem.GetOwner().GetAttachParentActor().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			float parentWidth = uuiitem.GetWidth();
			float parentHeight = uuiitem.GetHeight();
			float rootWidth = base.GetItem(4).GetAnchorOffsetX();
			float lineDefaultWidth = (parentWidth / 2f - rootWidth) * 2f;
			int num = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[this.Data.Value.Id];
			bool flag = num == this.Data.Value.ConsuleLength;
			int i;
			int j;
			for (i = 0; i < this.Data.Value.PostIdLength; i = j + 1)
			{
				RogueTalentTree? rogueTalentTreeById = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeById(this.Data.Value.PostId(i));
				int childLevel = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[rogueTalentTreeById.Value.Id];
				int offset = rogueTalentTreeById.Value.Row - this.Data.Value.Row;
				UUIItem outPosItem = this.GetOutPosItem(offset);
				if (this.LineComponentList.Count <= i || this.LineComponentList[i] == null)
				{
					Singleton<LguiUtil>.Instance.LoadPrefabByResourceIdAsync("UiItem_RoguelikeSkillLine", outPosItem, null, ResourceSystem.EResourceLoadPriority.Default, "js_undefined").ContinueWith(delegate(AActor prefab)
					{
						if (prefab == null)
						{
							return;
						}
						RoguelikeSkillLine component = new RoguelikeSkillLine();
						UUIItem uuiitem2 = prefab.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
						int curLevel = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[this.Data.Value.Id];
						if (offset == 0)
						{
							uuiitem2.SetWidth(lineDefaultWidth);
						}
						else
						{
							uuiitem2.SetWidth((float)Math.Sqrt((double)(parentWidth * parentWidth + parentHeight * parentHeight)) - rootWidth * 2f);
						}
						component.CreateThenShowByActorAsync(prefab, null, false).ContinueWith(delegate()
						{
							component.Refresh(curLevel > 0 && childLevel > 0, offset, this.Data.Value.Row);
						});
						while (this.LineComponentList.Count <= i)
						{
							this.LineComponentList.Add(null);
						}
						this.LineComponentList[i] = component;
					});
				}
				else
				{
					RoguelikeSkillLine roguelikeSkillLine = this.LineComponentList[i];
					int num2 = ModelBase<RoguelikeModel>.Instance.RoguelikeSkillDataMap[this.Data.Value.Id];
					roguelikeSkillLine.Refresh(num2 > 0 && childLevel > 0, offset, this.Data.Value.Row);
				}
				j = i;
			}
			RogueTalentTreeDesc? rogueTalentTreeDescConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeDescConfig(this.Data.Value.Describe);
			RogueParam? paramConfigBySeasonId = ModelBase<RoguelikeModel>.Instance.GetParamConfigBySeasonId(null);
			RoguelikeModel instance = ModelBase<RoguelikeModel>.Instance;
			int? num3 = (instance != null) ? new int?(instance.GetRoguelikeCurrency(paramConfigBySeasonId.Value.SkillPoint)) : null;
			bool flag2 = num >= 0 && num < this.Data.Value.ConsuleLength && num3.Value >= this.Data.Value.Consule(num);
			this.SetSpriteByPath(rogueTalentTreeDescConfig.Value.TalentIcon, base.GetSprite(9), false, null, null);
			if (num < 0)
			{
				base.GetItem(6).SetUIActive(true);
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(10).SetUIActive(false);
				base.GetItem(12).SetUIActive(true);
				base.GetSprite(9).SetColor(FColor.FromHex("808080"));
				return;
			}
			if (num == 0)
			{
				base.GetItem(6).SetUIActive(true);
				base.GetItem(7).SetUIActive(false);
				base.GetItem(8).SetUIActive(false);
				base.GetItem(10).SetUIActive(flag2);
				base.GetItem(12).SetUIActive(false);
				base.GetSprite(9).SetColor(FColor.FromHex("FFFFFF"));
				return;
			}
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(!flag);
			base.GetItem(8).SetUIActive(flag);
			base.GetItem(10).SetUIActive(!flag && flag2);
			base.GetItem(12).SetUIActive(false);
			base.GetSprite(9).SetColor(FColor.FromHex("FFFFFF"));
		}

		// Token: 0x06035C12 RID: 220178 RVA: 0x00D84ACA File Offset: 0x00D82CCA
		public UUIItem GetOutPosItem(int offset)
		{
			if (offset > 0)
			{
				return base.GetItem(5);
			}
			if (offset < 0)
			{
				return base.GetItem(3);
			}
			return base.GetItem(4);
		}

		// Token: 0x06035C13 RID: 220179 RVA: 0x00D84AEB File Offset: 0x00D82CEB
		public void SetToggleState(EToggleState state)
		{
			base.GetExtendToggle(11).SetToggleState(state, false, false, false);
		}

		// Token: 0x0401ED87 RID: 126343
		public RogueTalentTree? Data;

		// Token: 0x0401ED88 RID: 126344
		[Nullable(2)]
		public UUIItem PreItem;

		// Token: 0x0401ED89 RID: 126345
		public List<RoguelikeSkillLine> LineComponentList = new List<RoguelikeSkillLine>();

		// Token: 0x0401ED8A RID: 126346
		[Nullable(2)]
		public UUIItem GridPanelItem;

		// Token: 0x0200B17E RID: 45438
		[NullableContext(0)]
		public class ERoguelikeSkillNodeDefine
		{
			// Token: 0x040370B2 RID: 225458
			public const int InPos1 = 0;

			// Token: 0x040370B3 RID: 225459
			public const int InPos2 = 1;

			// Token: 0x040370B4 RID: 225460
			public const int InPos3 = 2;

			// Token: 0x040370B5 RID: 225461
			public const int OutPos1 = 3;

			// Token: 0x040370B6 RID: 225462
			public const int OutPos2 = 4;

			// Token: 0x040370B7 RID: 225463
			public const int OutPos3 = 5;

			// Token: 0x040370B8 RID: 225464
			public const int LockItem = 6;

			// Token: 0x040370B9 RID: 225465
			public const int UnlockItem = 7;

			// Token: 0x040370BA RID: 225466
			public const int ActivateItem = 8;

			// Token: 0x040370BB RID: 225467
			public const int SkillIcon = 9;

			// Token: 0x040370BC RID: 225468
			public const int UpItem = 10;

			// Token: 0x040370BD RID: 225469
			public const int Toggle = 11;

			// Token: 0x040370BE RID: 225470
			public const int SpriteLock = 12;
		}
	}
}
