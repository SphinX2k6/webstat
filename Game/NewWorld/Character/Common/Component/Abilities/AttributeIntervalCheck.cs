using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities
{
	// Token: 0x0200495F RID: 18783
	[NullableContext(1)]
	[Nullable(0)]
	public class AttributeIntervalCheck
	{
		// Token: 0x170083CB RID: 33739
		// (get) Token: 0x060311E8 RID: 201192 RVA: 0x00C3A038 File Offset: 0x00C38238
		public EAttributeType ListenAttributeId { get; }

		// Token: 0x170083CC RID: 33740
		// (get) Token: 0x060311E9 RID: 201193 RVA: 0x00C3A040 File Offset: 0x00C38240
		// (set) Token: 0x060311EA RID: 201194 RVA: 0x00C3A048 File Offset: 0x00C38248
		public EAttributeType? MaxAttributeId { get; private set; }

		// Token: 0x170083CD RID: 33741
		// (get) Token: 0x060311EB RID: 201195 RVA: 0x00C3A051 File Offset: 0x00C38251
		// (set) Token: 0x060311EC RID: 201196 RVA: 0x00C3A059 File Offset: 0x00C38259
		public float LowerBound { get; set; }

		// Token: 0x170083CE RID: 33742
		// (get) Token: 0x060311ED RID: 201197 RVA: 0x00C3A062 File Offset: 0x00C38262
		// (set) Token: 0x060311EE RID: 201198 RVA: 0x00C3A06A File Offset: 0x00C3826A
		public float UpperBound { get; set; }

		// Token: 0x170083CF RID: 33743
		// (get) Token: 0x060311EF RID: 201199 RVA: 0x00C3A073 File Offset: 0x00C38273
		public bool IsPerTenThousand { get; }

		// Token: 0x060311F0 RID: 201200 RVA: 0x00C3A07C File Offset: 0x00C3827C
		public AttributeIntervalCheck(EAttributeType listenId, float lowerBound, float upperBound, bool isPerTenThousandth)
		{
			this.ListenAttributeId = listenId;
			this.LowerBound = lowerBound;
			this.UpperBound = upperBound;
			this.IsPerTenThousand = isPerTenThousandth;
			if (this.IsPerTenThousand)
			{
				EAttributeType value;
				CharacterAttributeTypes.attributeIdsWithMax.TryGetValue(this.ListenAttributeId, out value);
				this.MaxAttributeId = new EAttributeType?(value);
			}
		}

		// Token: 0x060311F1 RID: 201201 RVA: 0x00C3A0D4 File Offset: 0x00C382D4
		public bool CheckListenActiveness(float newValue, BaseAttributeComponent listenAttributeComponent)
		{
			if (!this.IsPerTenThousand)
			{
				return newValue <= this.UpperBound && newValue > this.LowerBound;
			}
			float currentValue = listenAttributeComponent.GetCurrentValue(this.MaxAttributeId.Value);
			float num = newValue / currentValue * 10000f;
			return num <= this.UpperBound && num > this.LowerBound;
		}

		// Token: 0x060311F2 RID: 201202 RVA: 0x00C3A134 File Offset: 0x00C38334
		[NullableContext(2)]
		public bool CheckActiveness(BaseAttributeComponent targetAttributeComponent)
		{
			if (targetAttributeComponent == null)
			{
				return false;
			}
			float currentValue = targetAttributeComponent.GetCurrentValue(this.ListenAttributeId);
			if (!this.IsPerTenThousand)
			{
				return currentValue <= this.UpperBound && currentValue > this.LowerBound;
			}
			float currentValue2 = targetAttributeComponent.GetCurrentValue(this.MaxAttributeId.Value);
			float num = currentValue / currentValue2 * 10000f;
			return num <= this.UpperBound && num > this.LowerBound;
		}

		// Token: 0x060311F3 RID: 201203 RVA: 0x00C3A1A4 File Offset: 0x00C383A4
		public string GetDebugString()
		{
			string value = this.ListenAttributeId.ToString();
			EAttributeType? eattributeType;
			string text = (this.MaxAttributeId != null) ? eattributeType.GetValueOrDefault().ToString() : null;
			string value2 = this.IsPerTenThousand ? ((this.UpperBound * 0.0001f * 100f).ToString() + "%") : this.UpperBound.ToString(CultureInfo.InvariantCulture);
			string value3 = this.IsPerTenThousand ? ((this.LowerBound * 0.0001f * 100f).ToString() + "%") : this.LowerBound.ToString(CultureInfo.InvariantCulture);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 4);
			defaultInterpolatedStringHandler.AppendLiteral("属性");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("位于");
			defaultInterpolatedStringHandler.AppendFormatted((!string.IsNullOrEmpty(text)) ? (text + "的") : "");
			defaultInterpolatedStringHandler.AppendFormatted(value3);
			defaultInterpolatedStringHandler.AppendLiteral("~");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("之间");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}
}
