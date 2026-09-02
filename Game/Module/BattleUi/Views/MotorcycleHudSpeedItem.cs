using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006082 RID: 24706
	[NullableContext(2)]
	[Nullable(0)]
	public class MotorcycleHudSpeedItem : UiPanelBase
	{
		// Token: 0x0603E513 RID: 255251 RVA: 0x00FE9B0C File Offset: 0x00FE7D0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
			if (this.IsLeft)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIArtText)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(4, typeof(UUIArtText)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(5, typeof(UUIArtText)));
				return;
			}
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(8, typeof(UUITexture)));
		}

		// Token: 0x0603E514 RID: 255252 RVA: 0x00FE9C44 File Offset: 0x00FE7E44
		protected override void OnStart()
		{
			this.BarTexture = base.GetTexture(0);
			this.ArrowTexture = base.GetTexture(1);
			this.BarPointTexture = base.GetTexture(2);
			if (this.IsLeft)
			{
				this.NumText = base.GetArtText(3);
				this.NumTextStroke = base.GetArtText(4);
				this.NumTextGlow = base.GetArtText(5);
				this.ArrowTexture.SetUIActive(false);
			}
			else
			{
				this.SpeedItem = base.GetItem(6);
				this.AngleItem = base.GetItem(7);
				this.AngleTexture = base.GetTexture(8);
				this.SpeedItem.SetUIActive(true);
				this.AngleItem.SetUIActive(false);
				this.SetRootAlphaState(Singleton<UiManager>.Instance.IsViewShow(EUiViewName.InteractionHintView) ? MotorcycleHudSpeedItem.EAlphaState.Transparent : MotorcycleHudSpeedItem.EAlphaState.Normal, true);
				this.NodeAlphaMachine.Duration = ConfigCommonParamById.GetFloatConfig("MotorHudSoarRightNodeAlphaDuration").Value;
				this.SetNodeAlphaState(MotorcycleHudSpeedItem.ENodeAlphaState.Speed, true);
				this.LoadResource();
			}
			this.SpeedMachine.Init(0f, null);
			IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("MotorHudPointerYawRange");
			if (floatArrayConfig != null && floatArrayConfig.Count > 1)
			{
				this.StartYaw = floatArrayConfig[0];
				this.EndYaw = floatArrayConfig[1];
			}
			this.OnSpeedUpdate(0f);
		}

		// Token: 0x0603E515 RID: 255253 RVA: 0x00FE9D98 File Offset: 0x00FE7F98
		private void LoadResource()
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("MotorHudSoarAngleScaleCurve");
			Singleton<ResourceSystem>.Instance.LoadAsync<UCurveFloat>(stringConfig, delegate([Nullable(2)] UCurveFloat res, string _)
			{
				this.AngleScaleCurve = res;
			}, 100, "js_undefined");
		}

		// Token: 0x0603E516 RID: 255254 RVA: 0x00FE9DCF File Offset: 0x00FE7FCF
		protected override void OnBeforeShowImplement()
		{
			if (!this.IsLeft)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnInteractViewVisibleChanged, new Action<bool>(this.OnInteractViewVisibleChanged));
			}
		}

		// Token: 0x0603E517 RID: 255255 RVA: 0x00FE9DF5 File Offset: 0x00FE7FF5
		protected override void OnAfterHideImplement()
		{
			if (!this.IsLeft)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnInteractViewVisibleChanged, new Action<bool>(this.OnInteractViewVisibleChanged));
			}
		}

		// Token: 0x0603E518 RID: 255256 RVA: 0x00FE9E1C File Offset: 0x00FE801C
		public void SetSoarMode(bool vehicleSoar)
		{
			if (this.IsLeft)
			{
				return;
			}
			if (this.IsVehicleSoar == vehicleSoar)
			{
				return;
			}
			this.IsVehicleSoar = vehicleSoar;
			this.SpeedItem.SetUIActive(true);
			this.AngleItem.SetUIActive(true);
			this.SetNodeAlphaState(vehicleSoar ? MotorcycleHudSpeedItem.ENodeAlphaState.Angle : MotorcycleHudSpeedItem.ENodeAlphaState.Speed, false);
		}

		// Token: 0x0603E519 RID: 255257 RVA: 0x00FE9E69 File Offset: 0x00FE8069
		public void SetSpeed(float speed, float maxSpeed)
		{
			this.MaxSpeed = maxSpeed;
			this.SpeedMachine.SetTargetPercent(speed);
		}

		// Token: 0x0603E51A RID: 255258 RVA: 0x00FE9E80 File Offset: 0x00FE8080
		private void OnSpeedUpdate(float speed)
		{
			float num = (this.MaxSpeed > 0f) ? Math.Min(1f, speed / this.MaxSpeed) : 0f;
			if (!this.IsLeft && this.IsVehicleSoar && this.AngleScaleCurve != null)
			{
				num = this.AngleScaleCurve.GetFloatValue(num);
			}
			this.BarTexture.SetFillAmount(0.33f + num * 0.43f);
			if (!this.IsLeft && this.IsVehicleSoar)
			{
				UUIItem angleTexture = this.AngleTexture;
				FRotator frotator = new FRotator();
				frotator.Yaw = this.StartYaw + num * (this.EndYaw - this.StartYaw);
				angleTexture.SetUIRelativeRotation(frotator);
			}
			else
			{
				UUIItem arrowTexture = this.ArrowTexture;
				FRotator frotator = new FRotator();
				frotator.Yaw = this.StartYaw + num * (this.EndYaw - this.StartYaw);
				arrowTexture.SetUIRelativeRotation(frotator);
			}
			this.BarPointTexture.SetFillAmount(num);
			if (this.IsLeft)
			{
				string text = ((int)(speed * 0.036f)).ToString();
				this.NumText.SetText(text);
				UUIArtText numTextStroke = this.NumTextStroke;
				if (numTextStroke != null)
				{
					numTextStroke.SetText(text);
				}
				UUIArtText numTextGlow = this.NumTextGlow;
				if (numTextGlow == null)
				{
					return;
				}
				numTextGlow.SetText(text);
			}
		}

		// Token: 0x0603E51B RID: 255259 RVA: 0x00FE9FBC File Offset: 0x00FE81BC
		public void Tick(float delta)
		{
			if (this.SpeedMachine.Update(delta))
			{
				this.OnSpeedUpdate(this.SpeedMachine.GetCurPercent());
			}
			if (!this.IsLeft)
			{
				if (this.RootAlphaMachine.Update(delta))
				{
					base.GetRootItem().SetAlpha(this.RootAlphaMachine.GetCurPercent());
				}
				if (this.NodeAlphaMachine.Update(delta))
				{
					this.UpdateNodeAlpha(this.NodeAlphaMachine.GetCurPercent());
				}
			}
		}

		// Token: 0x0603E51C RID: 255260 RVA: 0x00FEA033 File Offset: 0x00FE8233
		private void OnInteractViewVisibleChanged(bool visible)
		{
			this.SetRootAlphaState(visible ? MotorcycleHudSpeedItem.EAlphaState.Transparent : MotorcycleHudSpeedItem.EAlphaState.Normal, false);
		}

		// Token: 0x0603E51D RID: 255261 RVA: 0x00FEA044 File Offset: 0x00FE8244
		private void SetRootAlphaState(MotorcycleHudSpeedItem.EAlphaState state, bool force = false)
		{
			if (state == this.RootAlphaState && !force)
			{
				return;
			}
			this.RootAlphaState = state;
			float num = (state == MotorcycleHudSpeedItem.EAlphaState.Normal) ? 1f : 0.2f;
			if (!force)
			{
				this.RootAlphaMachine.SetTargetPercent(num);
				return;
			}
			this.RootAlphaMachine.Init(num, new float?(300f));
			base.GetRootItem().SetAlpha(num);
		}

		// Token: 0x0603E51E RID: 255262 RVA: 0x00FEA0A8 File Offset: 0x00FE82A8
		private void SetNodeAlphaState(MotorcycleHudSpeedItem.ENodeAlphaState state, bool force = false)
		{
			if (state == this.NodeAlphaState && !force)
			{
				return;
			}
			this.NodeAlphaState = state;
			int num = (state > MotorcycleHudSpeedItem.ENodeAlphaState.Speed) ? 1 : 0;
			if (!force)
			{
				this.NodeAlphaMachine.SetTargetPercent((float)num);
				return;
			}
			this.NodeAlphaMachine.Init((float)num, null);
			this.UpdateNodeAlpha((float)num);
		}

		// Token: 0x0603E51F RID: 255263 RVA: 0x00FEA100 File Offset: 0x00FE8300
		private void UpdateNodeAlpha(float a)
		{
			this.SpeedItem.SetAlpha(Singleton<MathUtils>.Instance.Lerp(1f, 0f, a * 2f));
			this.AngleItem.SetAlpha(Singleton<MathUtils>.Instance.Lerp(0f, 1f, a * 2f - 1f));
		}

		// Token: 0x0603E520 RID: 255264 RVA: 0x00FEA15F File Offset: 0x00FE835F
		public void SetMainColor(in FLinearColor color)
		{
			UUITexture barPointTexture = this.BarPointTexture;
			if (barPointTexture == null)
			{
				return;
			}
			barPointTexture.SetColor(color.ToFColor(true));
		}

		// Token: 0x0603E521 RID: 255265 RVA: 0x00FEA178 File Offset: 0x00FE8378
		public void SetPointerColor(in FLinearColor color)
		{
			UUITexture arrowTexture = this.ArrowTexture;
			if (arrowTexture == null)
			{
				return;
			}
			arrowTexture.SetColor(color.ToFColor(true));
		}

		// Token: 0x0603E522 RID: 255266 RVA: 0x00FEA191 File Offset: 0x00FE8391
		public void SetNumTextColor(in FLinearColor color)
		{
			if (this.IsLeft)
			{
				UUIArtText numText = this.NumText;
				if (numText == null)
				{
					return;
				}
				numText.SetColor(color.ToFColor(true));
			}
		}

		// Token: 0x0603E523 RID: 255267 RVA: 0x00FEA1B2 File Offset: 0x00FE83B2
		public void SetNumTextStrokeColor(in FLinearColor color)
		{
			if (this.IsLeft)
			{
				UUIArtText numTextStroke = this.NumTextStroke;
				if (numTextStroke == null)
				{
					return;
				}
				numTextStroke.SetColor(color.ToFColor(true));
			}
		}

		// Token: 0x0603E524 RID: 255268 RVA: 0x00FEA1D3 File Offset: 0x00FE83D3
		public void SetNumTextGlowColor(in FLinearColor color)
		{
			if (this.IsLeft)
			{
				UUIArtText numTextGlow = this.NumTextGlow;
				if (numTextGlow == null)
				{
					return;
				}
				numTextGlow.SetColor(color.ToFColor(true));
			}
		}

		// Token: 0x04022ED0 RID: 143056
		private const float ALPHA_TARGET_VALUE = 0.2f;

		// Token: 0x04022ED1 RID: 143057
		private const float ALPHA_CHANGE_DURATION = 300f;

		// Token: 0x04022ED2 RID: 143058
		public bool IsLeft;

		// Token: 0x04022ED3 RID: 143059
		[Nullable(1)]
		private readonly MotorcyclePercentMachine SpeedMachine = new MotorcyclePercentMachine();

		// Token: 0x04022ED4 RID: 143060
		private UUITexture BarTexture;

		// Token: 0x04022ED5 RID: 143061
		private UUITexture ArrowTexture;

		// Token: 0x04022ED6 RID: 143062
		private UUITexture BarPointTexture;

		// Token: 0x04022ED7 RID: 143063
		private UUIArtText NumText;

		// Token: 0x04022ED8 RID: 143064
		private UUIArtText NumTextStroke;

		// Token: 0x04022ED9 RID: 143065
		private UUIArtText NumTextGlow;

		// Token: 0x04022EDA RID: 143066
		private UUITexture AngleTexture;

		// Token: 0x04022EDB RID: 143067
		private UUIItem SpeedItem;

		// Token: 0x04022EDC RID: 143068
		private UUIItem AngleItem;

		// Token: 0x04022EDD RID: 143069
		private float MaxSpeed;

		// Token: 0x04022EDE RID: 143070
		private float StartYaw = 30f;

		// Token: 0x04022EDF RID: 143071
		private float EndYaw = 175f;

		// Token: 0x04022EE0 RID: 143072
		[Nullable(1)]
		private MotorcyclePercentMachine RootAlphaMachine = new MotorcyclePercentMachine();

		// Token: 0x04022EE1 RID: 143073
		private MotorcycleHudSpeedItem.EAlphaState RootAlphaState;

		// Token: 0x04022EE2 RID: 143074
		[Nullable(1)]
		private MotorcyclePercentMachine NodeAlphaMachine = new MotorcyclePercentMachine();

		// Token: 0x04022EE3 RID: 143075
		private MotorcycleHudSpeedItem.ENodeAlphaState NodeAlphaState;

		// Token: 0x04022EE4 RID: 143076
		private UCurveFloat AngleScaleCurve;

		// Token: 0x04022EE5 RID: 143077
		private bool IsVehicleSoar;

		// Token: 0x0200C16B RID: 49515
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B8EF RID: 243951
			BarTexture,
			// Token: 0x0403B8F0 RID: 243952
			ArrowTexture,
			// Token: 0x0403B8F1 RID: 243953
			BarPointTexture,
			// Token: 0x0403B8F2 RID: 243954
			NumText,
			// Token: 0x0403B8F3 RID: 243955
			NumTextStroke,
			// Token: 0x0403B8F4 RID: 243956
			NumTextGlow,
			// Token: 0x0403B8F5 RID: 243957
			SpeedItem,
			// Token: 0x0403B8F6 RID: 243958
			AngleItem,
			// Token: 0x0403B8F7 RID: 243959
			AngleTexture
		}

		// Token: 0x0200C16C RID: 49516
		[NullableContext(0)]
		private enum EAlphaState
		{
			// Token: 0x0403B8F9 RID: 243961
			Normal,
			// Token: 0x0403B8FA RID: 243962
			Transparent
		}

		// Token: 0x0200C16D RID: 49517
		[NullableContext(0)]
		private enum ENodeAlphaState
		{
			// Token: 0x0403B8FC RID: 243964
			Speed,
			// Token: 0x0403B8FD RID: 243965
			Angle
		}
	}
}
