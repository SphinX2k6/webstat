using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock
{
	// Token: 0x02006B1D RID: 27421
	[NullableContext(1)]
	[Nullable(0)]
	public class RollBlockGameplayInfo
	{
		// Token: 0x06043C11 RID: 277521 RVA: 0x0117C6FC File Offset: 0x0117A8FC
		public RollBlockGameplayInfo(RollBlockGamePlayPbInfo info)
		{
			this.GroupId = info.GroupId;
			this.Difficulty = info.Difficulty;
			this.TotalDifficulty = info.TotalDifficultyCount;
			this.IsMainController = info.IsMainControl;
			this.EntityIds = new List<long>();
			if (info.InitInvisibleEntityIds != null)
			{
				foreach (long item in info.InitInvisibleEntityIds)
				{
					this.EntityIds.Add(item);
				}
			}
			if (info.InitVisibleEntityIds != null)
			{
				foreach (long item2 in info.InitVisibleEntityIds)
				{
					this.InitVisibleEntityIds.Add(item2);
				}
			}
			this.Width = info.GridSizeX;
			this.Height = info.GridSizeY;
			this.ShowTipsInputCount = info.ShowHintErrorInputCount;
			this.CameraTag = new int?(info.SubCameraTag);
			foreach (RbInput rbInput in info.AvailableInputs)
			{
				RbRollInput roll = rbInput.Roll;
				bool flag;
				if (roll == null)
				{
					flag = false;
				}
				else
				{
					RbGridDirection direction = roll.Direction;
					flag = true;
				}
				if (flag)
				{
					this.AvailableInputs.Add(rbInput.Roll.Direction);
				}
			}
			if (info.Rotation != null)
			{
				this.TmpRot = global::Rotator.Create(info.Rotation.Y, info.Rotation.Z, info.Rotation.X);
				FRotator frotator = this.TmpRot.ToUeRotator();
				this.Forward = global::Vector.Create(new FQuat(ref frotator).GetRightVector());
				this.Forward.Normalize(9.99999993922529E-09);
				this.Forward.MultiplyEqual(-1.0);
				frotator = this.TmpRot.ToUeRotator();
				this.Right = global::Vector.Create(new FQuat(ref frotator).GetForwardVector());
				this.Right.Normalize(9.99999993922529E-09);
				Aki.Protocol.Vector position = info.Position;
				double x = (double)((position != null) ? position.X : 0f);
				Aki.Protocol.Vector position2 = info.Position;
				double y = (double)((position2 != null) ? position2.Y : 0f);
				Aki.Protocol.Vector position3 = info.Position;
				this.TmpVec = global::Vector.Create(x, y, (double)((position3 != null) ? position3.Z : 0f));
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RollBlock;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[RollBlockGameplayInfo] 玩法中心位置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Loc", this.TmpVec);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x04025E21 RID: 155169
		public int GroupId;

		// Token: 0x04025E22 RID: 155170
		public int Difficulty;

		// Token: 0x04025E23 RID: 155171
		public int TotalDifficulty;

		// Token: 0x04025E24 RID: 155172
		public bool IsMainController;

		// Token: 0x04025E25 RID: 155173
		public List<long> EntityIds = new List<long>();

		// Token: 0x04025E26 RID: 155174
		public List<long> InitVisibleEntityIds = new List<long>();

		// Token: 0x04025E27 RID: 155175
		public global::Vector Forward;

		// Token: 0x04025E28 RID: 155176
		public global::Vector Right;

		// Token: 0x04025E29 RID: 155177
		public List<RbBaseComponent> RollBlockEntities = new List<RbBaseComponent>();

		// Token: 0x04025E2A RID: 155178
		public global::Vector TmpVec;

		// Token: 0x04025E2B RID: 155179
		public global::Rotator TmpRot;

		// Token: 0x04025E2C RID: 155180
		public int HasTipActorNum;

		// Token: 0x04025E2D RID: 155181
		public int Width;

		// Token: 0x04025E2E RID: 155182
		public int Height;

		// Token: 0x04025E2F RID: 155183
		public List<RbGridDirection> AvailableInputs = new List<RbGridDirection>();

		// Token: 0x04025E30 RID: 155184
		public Dictionary<string, List<RbBaseComponent>> IndexedEntityMap = new Dictionary<string, List<RbBaseComponent>>();

		// Token: 0x04025E31 RID: 155185
		public int ShowTipsInputCount;

		// Token: 0x04025E32 RID: 155186
		public bool ShowedTips;

		// Token: 0x04025E33 RID: 155187
		public bool MultiBlock;

		// Token: 0x04025E34 RID: 155188
		public int? CameraTag;

		// Token: 0x04025E35 RID: 155189
		public ERollBlockInitState InitState;
	}
}
