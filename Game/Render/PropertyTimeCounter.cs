using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200474F RID: 18255
	[NullableContext(2)]
	[Nullable(0)]
	public class PropertyTimeCounter
	{
		// Token: 0x0602F5FA RID: 194042 RVA: 0x00B3CCDC File Offset: 0x00B3AEDC
		public void Init(int id, ECharacterBodySpecifiedType bodyType, int sectionIndex, ECharacterSlotSpecifiedType slotType, FName propertyName, FKuroCurveFloat curveFloatData, FKuroCurveLinearColor curveColorData, float wholeTime, EPropertyCurveDataType dataType)
		{
			this.Id = id;
			this.BodyType = bodyType;
			this.SectionIndex = sectionIndex;
			this.SlotType = slotType;
			this.PropertyName = new FName?(propertyName);
			this.WholeTime = wholeTime;
			this.DataType = dataType;
			this.Counter = 0f;
			EPropertyCurveDataType dataType2 = this.DataType;
			if (dataType2 == EPropertyCurveDataType.Float)
			{
				this.CurveFloatData = curveFloatData;
				this.CurveColorData = null;
				return;
			}
			if (dataType2 != EPropertyCurveDataType.Color)
			{
				return;
			}
			this.CurveColorData = curveColorData;
			this.CurveFloatData = null;
		}

		// Token: 0x0401AF8F RID: 110479
		public int Id;

		// Token: 0x0401AF90 RID: 110480
		public float Factor;

		// Token: 0x0401AF91 RID: 110481
		public float WholeTime;

		// Token: 0x0401AF92 RID: 110482
		public float Counter;

		// Token: 0x0401AF93 RID: 110483
		public ECharacterBodySpecifiedType BodyType;

		// Token: 0x0401AF94 RID: 110484
		public int SectionIndex;

		// Token: 0x0401AF95 RID: 110485
		public ECharacterSlotSpecifiedType SlotType;

		// Token: 0x0401AF96 RID: 110486
		public FName? PropertyName;

		// Token: 0x0401AF97 RID: 110487
		public FKuroCurveFloat CurveFloatData;

		// Token: 0x0401AF98 RID: 110488
		public FKuroCurveLinearColor CurveColorData;

		// Token: 0x0401AF99 RID: 110489
		public EPropertyCurveDataType DataType;
	}
}
