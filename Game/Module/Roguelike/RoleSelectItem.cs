using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B8 RID: 20920
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleSelectItem : GridProxyAbstract<RogueGainEntry>
	{
		// Token: 0x06035C93 RID: 220307 RVA: 0x00D8713A File Offset: 0x00D8533A
		public override void Refresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x06035C94 RID: 220308 RVA: 0x00D87143 File Offset: 0x00D85343
		public void Update(RogueGainEntry rogueGainEntry)
		{
			this.RogueGainEntry = rogueGainEntry;
			this.RefreshPanel();
		}

		// Token: 0x06035C95 RID: 220309 RVA: 0x00D87152 File Offset: 0x00D85352
		public void SetLevelUpItem(bool bActive)
		{
			base.GetItem(7).SetUIActive(bActive);
		}

		// Token: 0x06035C96 RID: 220310 RVA: 0x00D87161 File Offset: 0x00D85361
		public void SetSecondColorForAttrItem(HashSet<long> affixEntryId)
		{
			this.NewAffixEntryIdList = affixEntryId;
			this.RefreshAffixEntryList();
		}

		// Token: 0x06035C97 RID: 220311 RVA: 0x00D87170 File Offset: 0x00D85370
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, this.DetailBtn);
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035C98 RID: 220312 RVA: 0x00D873A2 File Offset: 0x00D855A2
		protected override void OnStart()
		{
			this.RoleAttrLayout = new GenericLayout<RoleAttrItem, AffixEntry>(base.GetVerticalLayout(12), this.CreateRoleAttrItem, null, false, true);
		}

		// Token: 0x06035C99 RID: 220313 RVA: 0x00D873C0 File Offset: 0x00D855C0
		public void RefreshPanel()
		{
			this.RefreshRole();
			this.RefreshAffixEntryList();
			this.RefreshEmptyItem();
		}

		// Token: 0x06035C9A RID: 220314 RVA: 0x00D873D4 File Offset: 0x00D855D4
		private void RefreshRole()
		{
			if (ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(this.RogueGainEntry.ConfigId) == null)
			{
				return;
			}
			int num = Math.Min(5, this.RogueGainEntry.AffixEntryList.Count + 1);
			QualityInfo? qualityConfig = ConfigBase<ItemConfig>.Instance.GetQualityConfig(num);
			RogueQualityConfig? rogueQualityConfigByQualityId = ConfigBase<RoguelikeConfig>.Instance.GetRogueQualityConfigByQualityId(num);
			if (qualityConfig != null)
			{
				FColor color = FColor.FromHex(qualityConfig.Value.DropColor);
				base.GetTexture(0).SetColor(color);
				base.GetTexture(2).SetColor(color);
				base.GetSprite(3).SetColor(color);
			}
			if (rogueQualityConfigByQualityId != null)
			{
				FColor fcolor = FColor.FromHex(rogueQualityConfigByQualityId.Value.RoleNiagaraColor);
				FLinearColor value = new FLinearColor(ref fcolor);
				base.GetUiNiagara(9).SetNiagaraVarLinearColor("Color", value);
			}
			RoleDataBase roguelikeRoleData = ModelBase<RoguelikeModel>.Instance.GetRoguelikeRoleData(this.RogueGainEntry.ConfigId);
			RoleInfo roleConfig = roguelikeRoleData.GetRoleConfig();
			base.GetText(4).ShowTextNew(roleConfig.Name);
			string formationRoleCard = roleConfig.FormationRoleCard;
			int roleSkinId = roguelikeRoleData.GetRoleSkinId();
			if (roleSkinId != -1)
			{
				formationRoleCard = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinId).Value.FormationRoleCard;
			}
			base.SetTextureByPath(formationRoleCard, base.GetTexture(1), null, null);
		}

		// Token: 0x06035C9B RID: 220315 RVA: 0x00D87538 File Offset: 0x00D85738
		private void RefreshAffixEntryList()
		{
			this.RoleAttrLayout.RefreshByDataAsync(this.RogueGainEntry.AffixEntryList ?? new List<AffixEntry>(), false, null).ContinueWith(delegate()
			{
				if (this.NewAffixEntryIdList == null)
				{
					return;
				}
				RoleAttrItem lastRoleAttrItem = null;
				foreach (RoleAttrItem roleAttrItem in this.RoleAttrLayout.GetLayoutItemList())
				{
					HashSet<long> newAffixEntryIdList = this.NewAffixEntryIdList;
					if (newAffixEntryIdList != null && newAffixEntryIdList.Contains((long)roleAttrItem.AffixEntry.Id.Value))
					{
						roleAttrItem.SetSecondColor();
						roleAttrItem.RefreshPanel();
						lastRoleAttrItem = roleAttrItem;
					}
				}
				if (lastRoleAttrItem != null)
				{
					UUIScrollViewWithScrollbarComponent scrollView = base.GetScrollViewWithScrollbar(13);
					int count = 0;
					scrollView.OnLateUpdate.Bind(delegate(float deltaTime)
					{
						int count = count;
						count++;
						if (count == 2)
						{
							float height = lastRoleAttrItem.GetRootItem().GetHeight();
							float height2 = scrollView.GetViewport().GetUIItem().GetHeight();
							float height3 = scrollView.ContentUIItem.Get().GetHeight();
							float num;
							if (height > height2)
							{
								num = height3 - height2 * (float)((int)Math.Floor((double)(height / height2))) - height % height2 - 10f;
							}
							else
							{
								num = height3 - height2;
							}
							num = Math.Max(num, 0f);
							scrollView.ContentUIItem.Get().SetAnchorOffsetY(num);
							scrollView.OnLateUpdate.Unbind();
						}
					});
				}
			});
		}

		// Token: 0x06035C9C RID: 220316 RVA: 0x00D87580 File Offset: 0x00D85780
		private void RefreshEmptyItem()
		{
			UUIItem item = base.GetItem(8);
			List<AffixEntry> affixEntryList = this.RogueGainEntry.AffixEntryList;
			item.SetUIActive(((affixEntryList != null) ? affixEntryList.Count : 0) <= 0);
		}

		// Token: 0x0401EDB9 RID: 126393
		private RogueGainEntry RogueGainEntry;

		// Token: 0x0401EDBA RID: 126394
		private GenericLayout<RoleAttrItem, AffixEntry> RoleAttrLayout;

		// Token: 0x0401EDBB RID: 126395
		private HashSet<long> NewAffixEntryIdList;

		// Token: 0x0401EDBC RID: 126396
		private readonly Action DetailBtn = delegate()
		{
		};

		// Token: 0x0401EDBD RID: 126397
		private readonly Func<RoleAttrItem> CreateRoleAttrItem = () => new RoleAttrItem();

		// Token: 0x0200B199 RID: 45465
		[NullableContext(0)]
		public static class ERoleSelectItemCom
		{
			// Token: 0x04037135 RID: 225589
			public const int QualityBgTexture = 0;

			// Token: 0x04037136 RID: 225590
			public const int RoleTexture = 1;

			// Token: 0x04037137 RID: 225591
			public const int LineTexture = 2;

			// Token: 0x04037138 RID: 225592
			public const int BorderSprite = 3;

			// Token: 0x04037139 RID: 225593
			public const int RoleNameText = 4;

			// Token: 0x0403713A RID: 225594
			public const int DetailBtn = 5;

			// Token: 0x0403713B RID: 225595
			public const int AttrItem = 6;

			// Token: 0x0403713C RID: 225596
			public const int LevelUpItem = 7;

			// Token: 0x0403713D RID: 225597
			public const int EmptyItem = 8;

			// Token: 0x0403713E RID: 225598
			public const int QualityNiagara = 9;

			// Token: 0x0403713F RID: 225599
			public const int ViewportItem = 10;

			// Token: 0x04037140 RID: 225600
			public const int ContentItem = 11;

			// Token: 0x04037141 RID: 225601
			public const int AttrLayout = 12;

			// Token: 0x04037142 RID: 225602
			public const int ScrollComponent = 13;
		}
	}
}
