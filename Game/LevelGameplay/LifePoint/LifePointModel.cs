using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LifePoint
{
	// Token: 0x02006B43 RID: 27459
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LifePointModel : ModelBase<LifePointModel>
	{
		// Token: 0x06043D99 RID: 277913 RVA: 0x01189996 File Offset: 0x01187B96
		public string GetText(EPieceColorType color)
		{
			return this.ColorMap[color][4];
		}

		// Token: 0x06043D9A RID: 277914 RVA: 0x011899A6 File Offset: 0x01187BA6
		public string GetColorHex(EPieceColorType color)
		{
			return this.ColorMap[color][0];
		}

		// Token: 0x06043D9B RID: 277915 RVA: 0x011899B6 File Offset: 0x01187BB6
		public string GetFramePath(EPieceColorType color)
		{
			return this.ColorMap[color][1];
		}

		// Token: 0x06043D9C RID: 277916 RVA: 0x011899C8 File Offset: 0x01187BC8
		protected override bool OnInit()
		{
			this.ColorMap[EPieceColorType.Blue] = new string[]
			{
				"77CBFFFF",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_LeftPointFrmBlie.T_LeftPointFrmBlie",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureBlueNor.T_BgTextureBlueNor",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureBlue.T_BgTextureBlue",
				"LifePlay_Blue_Text"
			};
			this.ColorMap[EPieceColorType.Red] = new string[]
			{
				"FF8E90FF",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_LeftPointFrmRed.T_LeftPointFrmRed",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureRedNor.T_BgTextureRedNor",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureRed.T_BgTextureRed",
				"LifePlay_Red_Text"
			};
			this.ColorMap[EPieceColorType.Yellow] = new string[]
			{
				"FFCE89FF",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_LeftPointFrmYellow.T_LeftPointFrmYellow",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureYellowNor.T_BgTextureYellowNor",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureYellow.T_BgTextureYellow",
				"LifePlay_Yellow_Text"
			};
			this.ColorMap[EPieceColorType.Green] = new string[]
			{
				"ACFFB6FF",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_LeftPointFrmGreen.T_LeftPointFrmGreen",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureGreenNor.T_BgTextureGreenNor",
				"/Game/Aki/UI/UIResources/UiLevel/Image/LifePoint/T_BgTextureGreen.T_BgTextureGreen",
				"LifePlay_Green_Text"
			};
			this.DirectionParam[EDirection.Center] = -1f;
			this.DirectionParam[EDirection.Down] = 0.75f;
			this.DirectionParam[EDirection.Left] = 0.5f;
			this.DirectionParam[EDirection.Up] = 0.25f;
			this.DirectionParam[EDirection.Right] = 0f;
			this.AnimParam.MaxTime = (float)ConfigCommonParamById.GetIntConfig("LifePoint_MaxTime").Value;
			this.AnimParam.AccelerationRes = ConfigCommonParamById.GetFloatConfig("LifePoint_AccelerationResis").Value;
			this.AnimParam.MinInterval = (float)ConfigCommonParamById.GetIntConfig("LifePoint_MinInterval").Value;
			this.AnimParam.GridMinRate = ConfigCommonParamById.GetFloatConfig("LifePoint_GridMinSpeed").Value;
			this.AnimParam.GridMaxRate = ConfigCommonParamById.GetFloatConfig("LifePoint_GridMaxSpeed").Value;
			this.AnimParam.GridAccelerationTime = (float)ConfigCommonParamById.GetIntConfig("LifePoint_GridDuration").Value;
			return true;
		}

		// Token: 0x06043D9D RID: 277917 RVA: 0x01189BC4 File Offset: 0x01187DC4
		protected override bool OnClear()
		{
			this.ColorMap.Clear();
			this.GridTextureMap.Clear();
			this.HitGridTextureMap.Clear();
			this.DirectionParam.Clear();
			return true;
		}

		// Token: 0x06043D9E RID: 277918 RVA: 0x01189BF3 File Offset: 0x01187DF3
		public float CalcCountDownTime(int order)
		{
			return (float)((double)this.AnimParam.MaxTime * (-(float)Math.Exp((double)((float)(-(float)order) * this.AnimParam.AccelerationRes)) + 1.0) + (double)(this.AnimParam.MinInterval * (float)order));
		}

		// Token: 0x06043D9F RID: 277919 RVA: 0x01189C34 File Offset: 0x01187E34
		public float CalPlayRate(float time)
		{
			return Singleton<MathUtils>.Instance.Clamp((this.AnimParam.GridMinRate + (this.AnimParam.GridMaxRate - this.AnimParam.GridMinRate) * time) / this.AnimParam.GridAccelerationTime, this.AnimParam.GridMinRate, this.AnimParam.GridMaxRate);
		}

		// Token: 0x06043DA0 RID: 277920 RVA: 0x01189C94 File Offset: 0x01187E94
		public float BlendDirectionParam(float a1, EDirection a2Direction)
		{
			if (a1 < 0f)
			{
				return a1;
			}
			float num = this.DirectionParam[a2Direction];
			if (Math.Abs(a1 - num) == 0.5f)
			{
				return a1;
			}
			float num2;
			if (Math.Abs(a1 - num) > 0.5f)
			{
				num2 = (a1 + num - 1f) / 2f;
			}
			else
			{
				num2 = (a1 + num) / 2f;
			}
			if (num2 < 0f)
			{
				num2 += 1f;
			}
			return num2;
		}

		// Token: 0x06043DA1 RID: 277921 RVA: 0x01189D0C File Offset: 0x01187F0C
		public UniTask LoadDataAsync(ILifePoint config, int entityId)
		{
			LifePointModel.<LoadDataAsync>d__26 <LoadDataAsync>d__;
			<LoadDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadDataAsync>d__.<>4__this = this;
			<LoadDataAsync>d__.config = config;
			<LoadDataAsync>d__.entityId = entityId;
			<LoadDataAsync>d__.<>1__state = -1;
			<LoadDataAsync>d__.<>t__builder.Start<LifePointModel.<LoadDataAsync>d__26>(ref <LoadDataAsync>d__);
			return <LoadDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043DA2 RID: 277922 RVA: 0x01189D5F File Offset: 0x01187F5F
		public void UnloadData()
		{
			this.Entity = null;
			this.Config = null;
			this.GridTextureMap.Clear();
			this.HitGridTextureMap.Clear();
			this.IsDataInit = false;
			this.AudioMap.Clear();
			this.BonusRules = null;
		}

		// Token: 0x06043DA3 RID: 277923 RVA: 0x01189D9E File Offset: 0x01187F9E
		public void AddStep()
		{
			LevelGeneralNetworks.RequestEntitySendEvent(this.Entity.GetComponent<CreatureDataComponent>().GetCreatureDataId(), "LifePointPaint");
		}

		// Token: 0x06043DA4 RID: 277924 RVA: 0x01189DBC File Offset: 0x01187FBC
		public int GetStepBonus()
		{
			if (this.BonusRules == null)
			{
				return 0;
			}
			VarDefinePb entityVar = this.Entity.GetComponent<CreatureDataComponent>().GetEntityVar("染色次数");
			long? num = (entityVar != null) ? new long?(entityVar.Int) : null;
			if (num == null)
			{
				return 0;
			}
			long num2 = Singleton<MathUtils>.Instance.LongToNumber(num.Value);
			foreach (ILifePointMaxStepRewardRuleItem lifePointMaxStepRewardRuleItem in this.BonusRules)
			{
				if (num2 >= (long)lifePointMaxStepRewardRuleItem.PaintCount)
				{
					return lifePointMaxStepRewardRuleItem.AddStep;
				}
			}
			return 0;
		}

		// Token: 0x04025F20 RID: 155424
		public bool IsDataInit;

		// Token: 0x04025F21 RID: 155425
		[Nullable(2)]
		public ILifePoint Config;

		// Token: 0x04025F22 RID: 155426
		private readonly Dictionary<EPieceColorType, string[]> ColorMap = new Dictionary<EPieceColorType, string[]>();

		// Token: 0x04025F23 RID: 155427
		public Dictionary<EPieceColorType, UTexture2D> GridTextureMap = new Dictionary<EPieceColorType, UTexture2D>();

		// Token: 0x04025F24 RID: 155428
		public Dictionary<EPieceColorType, UTexture2D> HitGridTextureMap = new Dictionary<EPieceColorType, UTexture2D>();

		// Token: 0x04025F25 RID: 155429
		public Dictionary<EDirection, float> DirectionParam = new Dictionary<EDirection, float>();

		// Token: 0x04025F26 RID: 155430
		public FName ParamName = new FName("LocalFadeInoutRotate");

		// Token: 0x04025F27 RID: 155431
		public FColor InitColor = FColor.FromHex("FFFF00FF");

		// Token: 0x04025F28 RID: 155432
		public AnimParam AnimParam = new AnimParam();

		// Token: 0x04025F29 RID: 155433
		public string AudioEvent = "play_interact_life_point_click";

		// Token: 0x04025F2A RID: 155434
		public string RtpcCount = "mini_game_lifepoint_spreads_counting";

		// Token: 0x04025F2B RID: 155435
		public string RtpcGrids = "mini_game_lifepoint_spreading_grids";

		// Token: 0x04025F2C RID: 155436
		public string RtpcSpeed = "mini_game_lifepoint_spreading_speed";

		// Token: 0x04025F2D RID: 155437
		public Dictionary<int, float[]> AudioMap = new Dictionary<int, float[]>();

		// Token: 0x04025F2E RID: 155438
		public FColor DangerStepColor = FColor.FromHex("FF7D6EFF");

		// Token: 0x04025F2F RID: 155439
		public FColor NormalStepColor = FColor.FromHex("FFCB3FFF");

		// Token: 0x04025F30 RID: 155440
		[Nullable(2)]
		private Entity Entity;

		// Token: 0x04025F31 RID: 155441
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private ILifePointMaxStepRewardRuleItem[] BonusRules;
	}
}
