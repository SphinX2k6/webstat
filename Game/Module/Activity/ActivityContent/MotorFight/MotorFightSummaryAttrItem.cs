using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066DE RID: 26334
	public class MotorFightSummaryAttrItem : GridProxyAbstract<EMotorFightAttrShowType>
	{
		// Token: 0x06041BF7 RID: 269303 RVA: 0x010DCFD0 File Offset: 0x010DB1D0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041BF8 RID: 269304 RVA: 0x010DD0C0 File Offset: 0x010DB2C0
		public override void Refresh(EMotorFightAttrShowType type, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), MotorFightDefine.motorFightAttrShowTypeToName[type], Array.Empty<object>());
			AKSC_Entity aksc_Entity = null;
			if (type == EMotorFightAttrShowType.MainGun)
			{
				KscSubModelBase curSubModel = ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel;
				aksc_Entity = ((curSubModel != null) ? curSubModel.KscPlayerEntity : null);
			}
			else if (type == EMotorFightAttrShowType.Wingman)
			{
				aksc_Entity = (ControllerBase<KuroSimpleCombatController>.Instance.CurSubModel as MotorcycleArrowSubModel).MotorcycleKscEntity;
			}
			if (aksc_Entity == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorFightActivity;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "实体不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			UKSC_SkillComp skillComp = aksc_Entity.GetSkillComp();
			TMap<EKSC_AttrType, int> tmap;
			if (skillComp == null)
			{
				tmap = null;
			}
			else
			{
				UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
				tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
			}
			TMap<EKSC_AttrType, int> tmap2 = tmap;
			if (tmap2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MotorFightActivity;
				ELogAuthor author2 = ELogAuthor.CXJ;
				string message2 = "实体属性不存在";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("type", type);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			this.SetAttrText(tmap2);
			if (type == EMotorFightAttrShowType.MainGun)
			{
				int num2;
				float num = (float)(tmap2.TryGetValue(EKSC_AttrType.AttackSpeed, out num2) ? num2 : 1);
				int num3 = tmap2.TryGetValue(EKSC_AttrType.AttackSpeedChange, out num2) ? num2 : 0;
				int num4 = (int)Math.Ceiling((double)(num * (1f + (float)num3 * 0.0001f)));
				UUIText text = base.GetText(2);
				if (text == null)
				{
					return;
				}
				text.SetText(num4.ToString(), true);
				return;
			}
			else
			{
				MotorFightAttrShow value = ConfigBase<MotorFightConfig>.Instance.GetMotorFightAttrShowById(1019).Value;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), value.Name, Array.Empty<object>());
				int num5;
				tmap2.TryGetValue((EKSC_AttrType)value.AttriId, out num5);
				float value2 = (float)(num5 * value.Ratio) * 0.0001f;
				string value3 = value.IsNeedPercentSign ? "%" : "";
				UUIText text2 = base.GetText(2);
				if (text2 == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
				defaultInterpolatedStringHandler.AppendFormatted<float>(value2);
				defaultInterpolatedStringHandler.AppendFormatted(value3);
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
		}

		// Token: 0x06041BF9 RID: 269305 RVA: 0x010DD2B8 File Offset: 0x010DB4B8
		[NullableContext(1)]
		private void SetAttrText(TMap<EKSC_AttrType, int> attrs)
		{
			int num2;
			float num = (float)(attrs.TryGetValue(EKSC_AttrType.Atk, out num2) ? num2 : 1);
			int num3 = attrs.TryGetValue(EKSC_AttrType.AtkChange, out num2) ? num2 : 0;
			int num4 = (int)Math.Ceiling((double)(num * (1f + (float)num3 * 0.0001f)));
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.SetText(num4.ToString(), true);
			}
			float num5 = (float)(attrs.TryGetValue(EKSC_AttrType.Crit, out num2) ? num2 : 0);
			int num6 = attrs.TryGetValue(EKSC_AttrType.CritChange, out num2) ? num2 : 0;
			int value = (int)Math.Ceiling((double)(num5 * (1f + (float)num6 * 0.0001f) / 100f));
			UUIText text2 = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			if (text2 != null)
			{
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			int num7 = attrs.TryGetValue(EKSC_AttrType.CritDamage, out num2) ? num2 : 0;
			UUIText text3 = base.GetText(4);
			if (text3 == null)
			{
				return;
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(num7 / 100);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x04024AF0 RID: 150256
		public const int WINGMAN_ATTACK_SPEED_ID = 1019;

		// Token: 0x0200C70E RID: 50958
		private class EComponent
		{
			// Token: 0x0403D498 RID: 251032
			public const int TextAttrName = 0;

			// Token: 0x0403D499 RID: 251033
			public const int TextAttack = 1;

			// Token: 0x0403D49A RID: 251034
			public const int TextAttackSpeed = 2;

			// Token: 0x0403D49B RID: 251035
			public const int TextCrit = 3;

			// Token: 0x0403D49C RID: 251036
			public const int TextCritDamage = 4;

			// Token: 0x0403D49D RID: 251037
			public const int TextAttackSpeedTitle = 5;
		}
	}
}
