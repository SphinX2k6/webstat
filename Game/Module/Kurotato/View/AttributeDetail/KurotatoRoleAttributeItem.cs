using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.AttributeDetail
{
	// Token: 0x02005AD7 RID: 23255
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoRoleAttributeItem : GridProxyAbstract<IKurotatoRoleSkillInfo>
	{
		// Token: 0x170095A7 RID: 38311
		// (get) Token: 0x0603ACBF RID: 240831 RVA: 0x00EE9051 File Offset: 0x00EE7251
		// (set) Token: 0x0603ACC0 RID: 240832 RVA: 0x00EE9059 File Offset: 0x00EE7259
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public new IScrollViewDelegate<IGridProxy<IKurotatoRoleSkillInfo>, IKurotatoRoleSkillInfo> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x0603ACC1 RID: 240833 RVA: 0x00EE9062 File Offset: 0x00EE7262
		public override void Refresh(IKurotatoRoleSkillInfo data, bool isSelected, int gridIndex)
		{
			this.Update(data);
		}

		// Token: 0x0603ACC2 RID: 240834 RVA: 0x00EE906C File Offset: 0x00EE726C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ACC3 RID: 240835 RVA: 0x00EE9138 File Offset: 0x00EE7338
		public void Update(IKurotatoRoleSkillInfo data)
		{
			base.GetSprite(0).useChangeColor = (base.GridIndex % 2 == 1);
			KurotatoProperty value = ConfigBase<KurotatoConfig>.Instance.GetPropertyById(data.AttrId).Value;
			base.SetTextureByPath(value.Icon, base.GetTexture(1), null, null);
			base.GetText(2).ShowTextNew(value.ShowName);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.Desc, value.DescParamsIter().ToArray<string>());
			UUIText text = base.GetText(4);
			bool valueOrDefault = data.IsLocked.GetValueOrDefault();
			int num = valueOrDefault ? data.LockedValue.GetValueOrDefault() : data.Value;
			text.SetText(KurotatoUtil.GetPropertyShowValue(data.AttrId, (float)num), true);
			float rawValue = (float)data.Value;
			int? baseValue = data.BaseValue;
			KurotatoUtil.ApplyAttrColor(text, rawValue, (baseValue != null) ? new float?((float)baseValue.GetValueOrDefault()) : null, valueOrDefault);
		}

		// Token: 0x0200BB04 RID: 47876
		[NullableContext(0)]
		private enum ERoleAttrItemDefine
		{
			// Token: 0x04039B91 RID: 236433
			SpriteBg,
			// Token: 0x04039B92 RID: 236434
			AttrIconTexture,
			// Token: 0x04039B93 RID: 236435
			AttrNameText,
			// Token: 0x04039B94 RID: 236436
			TextDescription,
			// Token: 0x04039B95 RID: 236437
			AttrValue
		}
	}
}
