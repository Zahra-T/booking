# booking



### Developemnt

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Booking.AppDbContext
dotnet ef database update
```

### Endpoints

* Salons Endpoint:

    * Return all salons: 
    ```
     GET api/v1/salons/id
    ```
     
    * Add a salon:
    ```
     POST api/v1/salons
    ```

    * Update a salon:
    ```
     PUT api/v1/salons/id
    ```

    * Delete a salon:
    ```
     DELETE api/v1/salons/id
    ```


* Shows Endpoint:

    * Return all shows:
    ```
     GET api/v1/shows
    ```

    * Add a show:
    ```
     POST api/v1/shows
    ```

    * Update a show:
    ```
     PUT api/v1/shows/id
    ```

    * Delete a show:
    ```
     DELETE api/v1/shows/id
    ```



