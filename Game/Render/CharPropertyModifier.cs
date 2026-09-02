using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004750 RID: 18256
	[NullableContext(1)]
	[Nullable(0)]
	public class CharPropertyModifier : CharRenderBase
	{
		// Token: 0x0602F5FC RID: 194044 RVA: 0x00B3CD64 File Offset: 0x00B3AF64
		public override void Start()
		{
			this.IndexCount = 0;
			this.AllCurveData = new Dictionary<int, PropertyTimeCounter>();
			this.TempRemoveList = new List<int>();
			if (this.RenderComponent.UseMaterialContainerV2)
			{
				this.MaterialContainerV2 = (this.RenderComponent.GetComponent(13) as CharMaterialContainerV2);
				this.MaterialContainer = null;
			}
			else
			{
				this.MaterialContainer = (this.RenderComponent.GetComponent(1) as CharMaterialContainer);
				this.MaterialContainerV2 = null;
			}
			if (this.MaterialContainer == null && this.MaterialContainerV2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "材质属性编辑器初始化失败，不存在CharMaterialContainer";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			base.OnInitSuccess();
		}

		// Token: 0x0602F5FD RID: 194045 RVA: 0x00B3CE24 File Offset: 0x00B3B024
		public void UpdateCurveData(float delta, PropertyTimeCounter data)
		{
			data.Factor = data.Counter / data.WholeTime;
			if (data.DataType == EPropertyCurveDataType.Float)
			{
				float @float = RenderUtil.GetFloat(data.CurveFloatData, data.Factor);
				this.SetPropertyFloat(data.BodyType, data.SectionIndex, data.SlotType, data.PropertyName, @float);
			}
			else
			{
				FLinearColor color = RenderUtil.GetColor(data.CurveColorData, data.Factor);
				this.SetPropertyColor(data.BodyType, data.SectionIndex, data.SlotType, data.PropertyName, color);
			}
			data.Counter += delta;
		}

		// Token: 0x0602F5FE RID: 194046 RVA: 0x00B3CEC0 File Offset: 0x00B3B0C0
		public override void Update()
		{
			float deltaTime = base.GetDeltaTime();
			foreach (PropertyTimeCounter data in this.AllCurveData.Values)
			{
				this.UpdateCurveData(deltaTime, data);
			}
			foreach (PropertyTimeCounter propertyTimeCounter in this.AllCurveData.Values)
			{
				if (propertyTimeCounter.Counter >= propertyTimeCounter.WholeTime)
				{
					this.TempRemoveList.Add(propertyTimeCounter.Id);
				}
			}
			if (this.TempRemoveList.Count > 0)
			{
				foreach (int key in this.TempRemoveList)
				{
					this.AllCurveData.Remove(key);
				}
				this.TempRemoveList = new List<int>();
			}
		}

		// Token: 0x0602F5FF RID: 194047 RVA: 0x00B3CFE4 File Offset: 0x00B3B1E4
		public bool SetPropertyFloat(ECharacterBodySpecifiedType bodyType, int sectionIndex, ECharacterSlotSpecifiedType slotType, FName? propertyName, float value)
		{
			if (propertyName == null)
			{
				return false;
			}
			if (sectionIndex >= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.LSY, "SetColor: 不支持指定SectionIndex", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (this.MaterialContainer != null)
			{
				this.MaterialContainer.SetFloat(propertyName, value, bodyType, slotType);
				return true;
			}
			if (this.MaterialContainerV2 != null)
			{
				this.MaterialContainerV2.SetFloatUpdateParamPermanent(propertyName.Value, value, (EKuroCharBodySpecifiedType)bodyType, (EKuroCharSlotSpecifiedType)slotType, null);
				return true;
			}
			return false;
		}

		// Token: 0x0602F600 RID: 194048 RVA: 0x00B3D064 File Offset: 0x00B3B264
		public bool SetPropertyColor(ECharacterBodySpecifiedType bodyType, int sectionIndex, ECharacterSlotSpecifiedType slotType, FName? propertyName, FLinearColor value)
		{
			if (propertyName == null)
			{
				return false;
			}
			if (sectionIndex >= 0)
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.LSY, "SetColor: 不支持指定SectionIndex", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (this.MaterialContainer != null)
			{
				this.MaterialContainer.SetColor(propertyName, value, bodyType, slotType);
				return true;
			}
			if (this.MaterialContainerV2 != null)
			{
				this.MaterialContainerV2.SetColorUpdateParamPermanent(propertyName.Value, value, (EKuroCharBodySpecifiedType)bodyType, (EKuroCharSlotSpecifiedType)slotType, null);
				return true;
			}
			return false;
		}

		// Token: 0x0602F601 RID: 194049 RVA: 0x00B3D0E4 File Offset: 0x00B3B2E4
		public bool SetPropertyLinearFloat(ECharacterBodySpecifiedType bodyType, int sectionIndex, ECharacterSlotSpecifiedType slotType, FName propertyName, PD_CurveFloatData_C value, float factor = -1f)
		{
			if (this.MaterialContainer != null || this.MaterialContainerV2 != null)
			{
				if (factor < 0f)
				{
					this.IndexCount++;
					PropertyTimeCounter propertyTimeCounter = new PropertyTimeCounter();
					propertyTimeCounter.Init(this.IndexCount, bodyType, sectionIndex, slotType, propertyName, value.FloatData, null, value.Time, EPropertyCurveDataType.Float);
					this.AllCurveData[this.IndexCount] = propertyTimeCounter;
				}
				else
				{
					if (sectionIndex >= 0)
					{
						Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.LSY, "SetPropertyLinearFloat: 不支持指定SectionIndex", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					float @float = RenderUtil.GetFloat(value.FloatData, factor);
					if (this.MaterialContainer != null)
					{
						this.MaterialContainer.SetFloat(new FName?(propertyName), @float, bodyType, slotType);
						return true;
					}
					if (this.MaterialContainerV2 != null)
					{
						this.MaterialContainerV2.SetFloatUpdateParamPermanent(propertyName, @float, (EKuroCharBodySpecifiedType)bodyType, (EKuroCharSlotSpecifiedType)slotType, null);
						return true;
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F602 RID: 194050 RVA: 0x00B3D1CC File Offset: 0x00B3B3CC
		public bool SetPropertyLinearColor(ECharacterBodySpecifiedType bodyType, int sectionIndex, ECharacterSlotSpecifiedType slotType, FName propertyName, PD_CurveLinearColorData_C value, float factor = -1f)
		{
			if (this.MaterialContainer != null || this.MaterialContainerV2 != null)
			{
				if (factor < 0f)
				{
					this.IndexCount++;
					PropertyTimeCounter propertyTimeCounter = new PropertyTimeCounter();
					propertyTimeCounter.Init(this.IndexCount, bodyType, sectionIndex, slotType, propertyName, null, value.LinearColor, value.Time, EPropertyCurveDataType.Color);
					this.AllCurveData[this.IndexCount] = propertyTimeCounter;
				}
				else
				{
					if (sectionIndex >= 0)
					{
						Singleton<Log>.Instance.Error(ELogModule.RenderCharacter, ELogAuthor.LSY, "SetPropertyLinearColor: 不支持指定SectionIndex", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
					FLinearColor color = RenderUtil.GetColor(value.LinearColor, factor);
					if (this.MaterialContainer != null)
					{
						this.MaterialContainer.SetColor(new FName?(propertyName), color, bodyType, slotType);
						return true;
					}
					if (this.MaterialContainerV2 != null)
					{
						this.MaterialContainerV2.SetColorUpdateParamPermanent(propertyName, color, (EKuroCharBodySpecifiedType)bodyType, (EKuroCharSlotSpecifiedType)slotType, null);
						return true;
					}
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602F603 RID: 194051 RVA: 0x00B3D2B2 File Offset: 0x00B3B4B2
		public override int GetComponentId()
		{
			return 6;
		}

		// Token: 0x0602F604 RID: 194052 RVA: 0x00B3D2B5 File Offset: 0x00B3B4B5
		public override string GetStatName()
		{
			return "CharPropertyModifier";
		}

		// Token: 0x0401AF9A RID: 110490
		[Nullable(2)]
		private CharMaterialContainer MaterialContainer;

		// Token: 0x0401AF9B RID: 110491
		[Nullable(2)]
		private CharMaterialContainerV2 MaterialContainerV2;

		// Token: 0x0401AF9C RID: 110492
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, PropertyTimeCounter> AllCurveData;

		// Token: 0x0401AF9D RID: 110493
		private int IndexCount;

		// Token: 0x0401AF9E RID: 110494
		[Nullable(2)]
		private List<int> TempRemoveList;
	}
}
