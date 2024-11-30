using System.Reflection.Metadata;

namespace PNR_File_Maker
{
    partial class frmMain
    {
        string[] C_PNR_CREATION = { 
            "PassengerType",
            "DocType",
            "DocumentNo",
            "Nationality",
            "GivenName",
            "Surname",
            "FullName",
            "DateOfBirth",
            "Gender",
            "ExpireDate",
            "CountryOfResidence",
            "DocIssueCountry",
            "BookingReferenceId",
            "BookingReferenceType",
            "BookingDate",
            "SeatNo",
            "PortOfEmbark",
            "PortOfDisembark",
            "VisaNo",
            "VisaExpiryDate",
            "ReservationContactFirstName",
            "ReservationContactLastName",
            "ReservationContactGender",
            "PassengerEmail",
            "PassengerContact",
            "PassengerAddressLine1",
            "PassengerAddressLine2",
            "AgentID",
            "AgentEmail",
            "AgentContact",
            "PassengerHotelReservationName",
            "PassengerHotelReservationAddressLine1",
            "PassengerHotelReservationAddressLine2" 
        };

        string[] C_PNR_TICKERTING = {
            "BookingReferenceId",
            "DocumentNo",
            "TicketNumber",
            "TicketIssueDate",
            "TicketingCarrier",
            "FareBasis"
        };

        string[] C_PNR_PAX_DATA_UPDATE = {
            "BookingReferenceId",
            "DocumentNo",
            "PassengerContact",
            "PassengerEmail" 
        };

        string[] C_PNR_ITINERARY_UPDATE = {
            "BookingReferenceId",
            "DocumentNo",
            "NewDepartureDateTime",
            "NewArrivalDateTime"
        };

        string[] C_PNR_PAYMENT = {
            "BookingReferenceId",
            "DocumentNo", 
            "PaymentMethod",
            "PaymentAmount",
            "Currency",
            "TransactionDate"
        };

        string[] C_PNR_CHECKIN = { 
            "BookingReferenceId",
            "DocumentNo",
            "CheckInTime",
            "SeatNo",
            "BoardingPassIssued"
        };

        string[] C_PNR_BOARDING = {
            "BookingReferenceId",
            "DocumentNo",
            "BoardingTime",
            "Gate",
            "SeatNo"
        };

        string[] C_PNR_FLIGHT_STATUS_UPDATE = {
            "BookingReferenceId",
            "DocumentNo",
            "FlightStatus",
            "NewDepartureTime"
        };

        string[] C_PNR_DEPARTURE = {
            "BookingReferenceId",
            "DocumentNo",
            "ActualDepartureTime" 
        };

        string[] C_PNR_ARRIVAL = {
            "BookingReferenceId",
            "DocumentNo",
            "ActualArrivalTime" 
        };

        string[] C_PNR_TRANSFER = {
            "BookingReferenceId",
            "DocumentNo",
            "TransferLocation",
            "NextFlightNumber",
            "NextFlightDepartureTime" 
        };

        string[] C_PNR_BAGGAGE_HANDLING = {
            "BookingReferenceId",
            "DocumentNo",
            "BaggageTagNumber",
            "BaggageStatus",
            "BaggageDropOffLocation" 
        };

        string[] C_PNR_CHANGES = {
            "BookingReferenceId",
            "DocumentNo",
            "ChangeType",
            "NewFlightNumber",
            "NewDepartureDateTime" 
        };

        string[] C_PNR_WAIT_LIST_CLEARANCE = {
            "BookingReferenceId",
            "DocumentNo",
            "ClearedSeatNo" 
        };

        string[] C_PNR_NOSHOW = {
            "BookingReferenceId",
            "DocumentNo",
            "FlightNumber",
            "NoShowStatus" 
        };

        string[] C_PNR_UPGRADE_DOWNGRADE = {
            "BookingReferenceId",
            "DocumentNo",
            "FlightNumber",
            "OldSeatNo",
            "NewSeatNo" 
        };

        string[] C_PNR_SPECIAL_SERVICE_REQUEST = {
            "BookingReferenceId",
            "DocumentNo",
            "FlightNumber",
            "SSRCode",
            "RequestDetails" 
        };

        string[] C_PNR_FREQUENT_FLYER_CREDIT = {
            "BookingReferenceId",
            "DocumentNo",
            "FlightNumber",
            "FrequentFlyerNumber",
            "MilesCredited" 
        };

        string[] C_PNR_REMARK = {
            "BookingReferenceId",
            "DocumentNo",
            "RemarkText" 
        };

        string[] C_PNR_CLOSURE = {
            "BookingReferenceId",
            "DocumentNo",
            "ClosureDate" 
        };

    }
}
