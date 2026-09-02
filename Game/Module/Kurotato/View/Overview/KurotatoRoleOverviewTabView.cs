using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Activity.ActivityContent.Encircle;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.Overview
{
	// Token: 0x02005A9C RID: 23196
	public class KurotatoRoleOverviewTabView : UiTabViewBase
	{
		// Token: 0x0603AB01 RID: 240385 RVA: 0x00EDFB20 File Offset: 0x00EDDD20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(USpineSkeletonAnimationComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603AB02 RID: 240386 RVA: 0x00EDFC30 File Offset: 0x00EDDE30
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoRoleOverviewTabView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoRoleOverviewTabView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB03 RID: 240387 RVA: 0x00EDFC74 File Offset: 0x00EDDE74
		private UniTask CreateAttributePanelAsync()
		{
			KurotatoRoleOverviewTabView.<CreateAttributePanelAsync>d__5 <CreateAttributePanelAsync>d__;
			<CreateAttributePanelAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateAttributePanelAsync>d__.<>4__this = this;
			<CreateAttributePanelAsync>d__.<>1__state = -1;
			<CreateAttributePanelAsync>d__.<>t__builder.Start<KurotatoRoleOverviewTabView.<CreateAttributePanelAsync>d__5>(ref <CreateAttributePanelAsync>d__);
			return <CreateAttributePanelAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603AB04 RID: 240388 RVA: 0x00EDFCB8 File Offset: 0x00EDDEB8
		protected override void OnShowUiTabViewFromToggle()
		{
			UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
			if (tabBehavior != null)
			{
				tabBehavior.PlaySequence("Switch");
			}
			KurotatoInstInfo kurotatoInstInfo = this.ExtraParams as KurotatoInstInfo;
			this.RefreshExp(kurotatoInstInfo);
			this.RefreshRoleInfo(kurotatoInstInfo);
			if (kurotatoInstInfo != null)
			{
				this.AttributePanel.SetSavePropertyMap(kurotatoInstInfo.PropertyMap.ToDictionary<int, int>());
				return;
			}
			this.AttributePanel.SetSavePropertyMap(null);
		}

		// Token: 0x0603AB05 RID: 240389 RVA: 0x00EDFD1C File Offset: 0x00EDDF1C
		[NullableContext(2)]
		private void RefreshExp(KurotatoInstInfo saveInstInfo)
		{
			KurotatoConfig instance = ConfigBase<KurotatoConfig>.Instance;
			KurotatoModel instance2 = ModelBase<KurotatoModel>.Instance;
			int characterId = (saveInstInfo != null) ? saveInstInfo.RoleId : instance2.GetRoleId();
			KurotatoCharacter value = instance.GetCharacterById(characterId).Value;
			int num = (saveInstInfo != null) ? saveInstInfo.RoleLevel : instance2.BattleData.GetRoleLevel();
			int num2 = (saveInstInfo != null) ? saveInstInfo.RoleExp : instance2.BattleData.GetRoleExp();
			KurotatoLevel value2 = instance.GetLevelConfig((saveInstInfo != null) ? saveInstInfo.LevelId : instance2.GetCurLevelId()).Value;
			int maxLevel = instance.GetMaxLevel(value2.ActivityId);
			UUISprite sprite = base.GetSprite(0);
			if (num <= 0)
			{
				sprite.SetFillAmount(0f);
			}
			else if (num >= maxLevel)
			{
				sprite.SetFillAmount(1f);
			}
			else
			{
				int expByLevel = instance.GetExpByLevel(num, value2.ActivityId);
				int expByLevel2 = instance.GetExpByLevel(num + 1, value2.ActivityId);
				sprite.SetFillAmount((float)(num2 - expByLevel) / (float)(expByLevel2 - expByLevel));
			}
			base.GetText(1).SetText(num.ToString(), true);
			List<string> data = new List<string>
			{
				KurotatoUtil.GetCardDesc(value.Desc, value.DescParamsIter().ToList<string>(), 0, 0, false)
			};
			this.SkillInfoLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0603AB06 RID: 240390 RVA: 0x00EDFE6C File Offset: 0x00EDE06C
		[NullableContext(2)]
		private void RefreshRoleInfo(KurotatoInstInfo saveInstInfo)
		{
			KurotatoModel instance = ModelBase<KurotatoModel>.Instance;
			int num = (saveInstInfo != null) ? saveInstInfo.RoleId : instance.GetRoleId();
			KurotatoCharacter value = ConfigBase<KurotatoConfig>.Instance.GetCharacterById(num).Value;
			RoleDataBase roleDataByKurotatoRoleId = instance.GetRoleDataByKurotatoRoleId(num);
			RoleSkin value2 = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleDataByKurotatoRoleId.GetRoleSkinId()).Value;
			USpineSkeletonAnimationComponent roleSpine = base.GetSpine(3);
			UUIItem roleItem = roleSpine.GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			List<float> param = value2.SpineParamIter().ToList<float>();
			base.SetSpineAssetByPath(value2.FormationSpineAtlas, value2.FormationSpineSkeletonData, roleSpine).ContinueWith(delegate()
			{
				roleSpine.SetAnimation(0, ESpineAnimation.Idle.ToEnumString(), true);
				roleItem.SetAnchorOffsetX(param[0]);
				roleItem.SetAnchorOffsetY(param[1]);
				roleItem.SetUIItemScale(new FVector(param[2], param[2], param[2]));
			}).Forget();
			base.GetText(4).ShowTextNew(value.Name);
		}

		// Token: 0x040212F2 RID: 135922
		[Nullable(1)]
		private readonly KurotatoAttributePanel AttributePanel = new KurotatoAttributePanel();

		// Token: 0x040212F3 RID: 135923
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<SkillInfoItem, string> SkillInfoLayout;

		// Token: 0x0200BA96 RID: 47766
		private enum EChildComp
		{
			// Token: 0x040399CF RID: 235983
			SpriteBar,
			// Token: 0x040399D0 RID: 235984
			TextLevel,
			// Token: 0x040399D1 RID: 235985
			AttributeViewItem,
			// Token: 0x040399D2 RID: 235986
			SpineRole,
			// Token: 0x040399D3 RID: 235987
			TextRoleName,
			// Token: 0x040399D4 RID: 235988
			VerticalLayoutSkill,
			// Token: 0x040399D5 RID: 235989
			PanelSkillInfo
		}
	}
}
