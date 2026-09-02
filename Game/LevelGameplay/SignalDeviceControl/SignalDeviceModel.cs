using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.LevelGamePlay.SignalDeviceControl
{
	// Token: 0x02006AFA RID: 27386
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SignalDeviceModel : ModelBase<SignalDeviceModel>
	{
		// Token: 0x1700A2FB RID: 41723
		// (get) Token: 0x06043B0E RID: 277262 RVA: 0x01175043 File Offset: 0x01173243
		public static int ROWNUM
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x06043B0F RID: 277263 RVA: 0x01175048 File Offset: 0x01173248
		public void InitData(List<IColorPiece> config)
		{
			this.GridStateArray = new List<IGridState>(this.GridNum);
			for (int i = 0; i < this.GridNum; i++)
			{
				this.GridStateArray.Add(new GridState
				{
					IsFinished = false,
					Color = config[i].Color
				});
			}
			this.ResetLinking();
		}

		// Token: 0x06043B10 RID: 277264 RVA: 0x011750A8 File Offset: 0x011732A8
		public void ResetData()
		{
			foreach (IGridState gridState in this.GridStateArray)
			{
				gridState.IsFinished = false;
			}
			this.ResetLinking();
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalDeviceReset);
		}

		// Token: 0x06043B11 RID: 277265 RVA: 0x01175110 File Offset: 0x01173310
		public bool IsGridFinished(int index)
		{
			IGridState gridState = this.GridStateArray.ElementAtOrDefault(index);
			return gridState != null && gridState.IsFinished;
		}

		// Token: 0x06043B12 RID: 277266 RVA: 0x01175129 File Offset: 0x01173329
		public EPieceColorType GetGridColor(int index)
		{
			IGridState gridState = this.GridStateArray.ElementAtOrDefault(index);
			if (gridState == null)
			{
				return EPieceColorType.White;
			}
			return gridState.Color;
		}

		// Token: 0x06043B13 RID: 277267 RVA: 0x01175142 File Offset: 0x01173342
		public void LinkingStart(int index, EPieceColorType color)
		{
			this.CurrentColor = color;
			this.LinkingArray = new List<int>
			{
				index
			};
		}

		// Token: 0x06043B14 RID: 277268 RVA: 0x01175160 File Offset: 0x01173360
		public void Linking(int index)
		{
			int num = this.LinkingArray[this.LinkingArray.Count - 1];
			if (!this.LinkingArray.Contains(index) && this.NeighboringType(num, index) != ENeighborType.None && this.LinkingValid(index))
			{
				this.LinkingArray.Add(index);
				Singleton<EventSystem>.Instance.Emit<bool, int, bool, int, bool>(EEventName.OnSignalDeviceLinking, true, num, this.GridStateArray[num].Color == this.CurrentColor, index, this.GridStateArray[index].Color == this.CurrentColor);
				if (this.GridStateArray[index].Color == this.CurrentColor)
				{
					this.CheckLinking(index);
					return;
				}
			}
			else if (this.LinkingArray.Count > 1 && this.LinkingArray.IndexOf(index) == this.LinkingArray.Count - 2)
			{
				this.LinkingArray.RemoveAt(this.LinkingArray.Count - 1);
				Singleton<EventSystem>.Instance.Emit<bool, int, bool, int, bool>(EEventName.OnSignalDeviceLinking, false, num, this.GridStateArray[num].Color == this.CurrentColor, index, this.GridStateArray[index].Color == this.CurrentColor);
			}
		}

		// Token: 0x06043B15 RID: 277269 RVA: 0x011752A8 File Offset: 0x011734A8
		public ENeighborType NeighboringType(int indexFrom, int indexTo)
		{
			int num = indexFrom - indexTo;
			if ((num == -1 && indexTo % 5 == 0) || (num == 1 && indexFrom % 5 == 0))
			{
				return ENeighborType.None;
			}
			if (num <= -1)
			{
				if (num == -5)
				{
					return ENeighborType.ToDown;
				}
				if (num == -1)
				{
					return ENeighborType.ToRight;
				}
			}
			else
			{
				if (num == 1)
				{
					return ENeighborType.ToLeft;
				}
				if (num == 5)
				{
					return ENeighborType.ToUp;
				}
			}
			return ENeighborType.None;
		}

		// Token: 0x06043B16 RID: 277270 RVA: 0x011752F0 File Offset: 0x011734F0
		private bool LinkingValid(int index)
		{
			return (this.GridStateArray[index].Color == EPieceColorType.White && !this.GridStateArray[index].IsFinished) || this.GridStateArray[index].Color == this.CurrentColor;
		}

		// Token: 0x06043B17 RID: 277271 RVA: 0x01175340 File Offset: 0x01173540
		public void CheckLinking(int index)
		{
			if (this.LinkingArray.Count == 0)
			{
				return;
			}
			int index2 = this.LinkingArray[this.LinkingArray.Count - 1];
			if (this.GetGridColor(index2) != this.CurrentColor || this.LinkingArray.Count == 1)
			{
				this.CancelCurrentLinking();
				return;
			}
			this.MarkCurrentLinking();
		}

		// Token: 0x06043B18 RID: 277272 RVA: 0x011753A0 File Offset: 0x011735A0
		public void MarkCurrentLinking()
		{
			Singleton<EventSystem>.Instance.Emit<bool, IReadOnlyList<int>>(EEventName.OnSignalDeviceLinkingCheck, true, this.LinkingArray);
			foreach (int index in this.LinkingArray)
			{
				this.GridStateArray[index].IsFinished = true;
			}
			this.ResetLinking();
			if (this.CheckFinished())
			{
				this.RequestFinish();
			}
		}

		// Token: 0x06043B19 RID: 277273 RVA: 0x0117542C File Offset: 0x0117362C
		public void CancelCurrentLinking()
		{
			Singleton<EventSystem>.Instance.Emit<bool, IReadOnlyList<int>>(EEventName.OnSignalDeviceLinkingCheck, false, this.LinkingArray);
			this.ResetLinking();
		}

		// Token: 0x06043B1A RID: 277274 RVA: 0x0117544C File Offset: 0x0117364C
		private bool CheckFinished()
		{
			foreach (IGridState gridState in this.GridStateArray)
			{
				if (gridState.Color != EPieceColorType.White && !gridState.IsFinished)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06043B1B RID: 277275 RVA: 0x011754B0 File Offset: 0x011736B0
		private void RequestFinish()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnSignalDeviceFinish);
			TimerSystem.Instance.Delay(delegate(float _)
			{
				UiGamePlayRequest uiGamePlayRequest = UiGamePlayRequest.Create();
				uiGamePlayRequest.GamePlayKey = "0";
				uiGamePlayRequest.Type = UiGamePlayType.SignalDevice;
				Singleton<Net>.Instance.Call<UiGamePlayResponse>(ERequestMessageId.UiGamePlayRequest, uiGamePlayRequest, delegate(UiGamePlayResponse response, Net.CallbackStatus _)
				{
					if (response.ErrorId == ErrorCode.Success)
					{
						this.ClearData();
						ControllerBase<SignalDeviceController>.Instance.CallFinishCallback();
					}
				}, 0);
			}, (float)((int)(1.7 * (double)Singleton<TimeUtil>.Instance.InverseMillisecond)), null, null, true, 1f);
		}

		// Token: 0x06043B1C RID: 277276 RVA: 0x01175503 File Offset: 0x01173703
		private void ClearData()
		{
			this.GridStateArray.Clear();
			this.ResetLinking();
		}

		// Token: 0x06043B1D RID: 277277 RVA: 0x01175516 File Offset: 0x01173716
		private void ResetLinking()
		{
			this.LinkingArray.Clear();
			this.CurrentColor = EPieceColorType.White;
		}

		// Token: 0x04025D20 RID: 154912
		public int GridNum = 25;

		// Token: 0x04025D21 RID: 154913
		private List<IGridState> GridStateArray = new List<IGridState>();

		// Token: 0x04025D22 RID: 154914
		private List<int> LinkingArray = new List<int>();

		// Token: 0x04025D23 RID: 154915
		public EPieceColorType CurrentColor;

		// Token: 0x04025D24 RID: 154916
		public global::Rotator CacheRotator = global::Rotator.Create(0f, 0f, 0f);

		// Token: 0x04025D25 RID: 154917
		public EViewType ViewType;

		// Token: 0x04025D26 RID: 154918
		public readonly Dictionary<ENeighborType, int> RotateMap = new Dictionary<ENeighborType, int>
		{
			{
				ENeighborType.None,
				0
			},
			{
				ENeighborType.ToDown,
				-90
			},
			{
				ENeighborType.ToUp,
				90
			},
			{
				ENeighborType.ToLeft,
				180
			},
			{
				ENeighborType.ToRight,
				0
			}
		};
	}
}
